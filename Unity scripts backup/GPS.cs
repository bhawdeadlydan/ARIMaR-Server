using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }

    public LocationHandler locationScript;
    public UtilsMath utilsScript;

    // floats, doubles and ints
    //GPS stuff
    public float latitude; //41.15973
    public float longitude; //-8.624739

    /////////////////////////////////////////////////////////// Moving Window Algorithm instance variables

    public float lastWindowLatitude;
    public float lastWindowLongitude;
    public double lastWindowTimestamp;
    public float accelerationValue;

    //threshould values, update them on the Unity's Inspector tab (ARCamera GameObject)
    public float minWindowSpeed;// 0.5m/s
    public float maxWindowSpeed; // 3 m/s
    public float minWindowAcceleration;// 0.45 m/s^2
    public float maxWindowAcceleration; // 3.09m/s^2
    public float GPSmaxDifDistance;// 10m

    // lists to calculate the averages
    public List<float> latitudeWindowList;
    public List<float> longitudeWindowList;
    public List<double> timestampsWindowList;
    public List<float> speedWindowList;
    public List<float> distanceWindowList;

    //booleans
    private bool firstWindowReadings;

    //counts init
    private int windowGPScount;
    private int firstValues;
    private int initialisingIterations;

    //floats init
    private float movingLatitudeAverage;
    private float movingLongitudeAverage;
    private float movingSpeedAverage;
    private float movingSpeedDeviation;
    private float movingAccelerationAverage;
    private float movingDistanceAverage;

    /////////////////////////////////////////////////// end of the Moving Window Algorithm Stuff

    //Camera Stuff
    public float XCamera;
    public float ZCamera;

    private float lastX;
    private float lastZ;

    //camera container
    private GameObject cameraContainer;

    // moving camera velocity
    public float smooth;

    //GPS and compass counts
    private int gpsCount;
    private int compassCount;

    //canvas
    public Text coordinates;
    public Text debugGPS;

    //booleans
    public bool gpsEnabled;
    private bool compassV;
    private bool gpsV;
    private bool firstCamera;

    //arrays
    private float[] compassValuesArray;
    private float[] gpsValuesArrayLatitude;
    private float[] gpsValuesArrayLongitude;

    /// <summary>
    /// Initialising all the stuff
    /// </summary>
    private void Start()
    {
        //Instance
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //GPS start
        StartCoroutine(StartLocationService());

        debugGPS.text = "Debug: Application Started";

        //booleans init
        compassV = false;
        gpsV = false;
        gpsEnabled = false;
        firstCamera = true;
        firstWindowReadings = true;

        //arrays init
        compassValuesArray = new float[10];
        //gpsValuesArrayLatitude = new float[10];
        //gpsValuesArrayLongitude = new float[10];

        //counts init
        compassCount = 0;
        //gpsCount = 0;
        windowGPScount = 0;
        firstValues = 0;

        // number of iterations necessary to build the window os values
        initialisingIterations = 10;

        // first values must be 0 until the acceleration calculus
        accelerationValue = 0f;

        // set camera container as parent of Vuforia camera to rotate it
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        //set camera rotation to 0
        cameraContainer.transform.rotation = Quaternion.identity;
        //set camera altitude
        cameraContainer.transform.position = new Vector3(0, 1.8f, 0);

        //moving window inits
        latitudeWindowList = new List<float>();
        longitudeWindowList = new List<float>();
        speedWindowList = new List<float>();
        distanceWindowList = new List<float>();
        timestampsWindowList = new List<double>();

    }

    /// <summary>
    /// Moving Window Algorithm to give us a more steady GPS signal
    /// </summary>
    private void Update()
    {
        // key inputs to move the camera
        if (Input.GetKey(KeyCode.RightArrow))
        {
            longitude += 0.000003f;
            //transform.position += new Vector3(0.4f, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            latitude += 0.000005f;
            //transform.position += new Vector3(0, 0, 0.4f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            longitude -= 0.000003f;
            //transform.position += new Vector3(-0.4f, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            latitude -= 0.000005f;
            //transform.position += new Vector3(0, 0, -0.4f);
        }

        // if GPS is enabled 
        if (gpsEnabled)
        {

            //Moving Window algorithm
            //if it is the first GPS Readings
            if (firstWindowReadings)
            {
                // get the first readings
                lastWindowLatitude = Input.location.lastData.latitude;
                lastWindowLongitude = Input.location.lastData.longitude;
                lastWindowTimestamp = Input.location.lastData.timestamp;

                //print
                utilsScript.WriteToFile("\n\n[GPS Script]: First GPS Readings (lat and long): " + lastWindowLatitude + " - " + lastWindowLongitude);

                //add values to list
                latitudeWindowList.Add(lastWindowLatitude);
                longitudeWindowList.Add(lastWindowLongitude);
                timestampsWindowList.Add(lastWindowTimestamp);

                //update counts and booleans
                windowGPScount++;
                firstValues++;
                firstWindowReadings = false;

                // update the Unity general latitude and longitude values
                latitude = lastWindowLatitude;
                longitude = lastWindowLongitude;

            }
            //if it is not the first GPS Readings
            else
            {
                // get lat and long updated values
                float newlatitude = Input.location.lastData.latitude;
                float newlongitude = Input.location.lastData.longitude;
                double newTimestamp = Input.location.lastData.timestamp;

                // calculate the difference between the coordinate to comparison
                float latdif = Math.Abs(lastWindowLatitude - newlatitude);
                float longdif = Math.Abs(lastWindowLongitude - newlongitude);

                // if GPS reading changes verifies if the readings are good enough
                if (latdif > 0.00001f || longdif > 0.000001f)
                {
                    //calculates the distance between the last and the new GPS values
                    float dist = locationScript.DistanceWindow(lastWindowLatitude, lastWindowLongitude, newlatitude, newlongitude);

                    // if the distance if less than GPSmaxDifDistance meters it is a possible good value
                    if (dist < GPSmaxDifDistance)
                    {
                        //print
                        utilsScript.WriteToFile("\n\n\n[GPS Script]: new lat, long, and timestamp readings: " + newlatitude + " - " + newlongitude + " - " + newTimestamp);

                        //print
                        utilsScript.WriteToFile("\n[GPS Script]: Moving Window distance: " + dist + " meters");

                        // time diference between the two readings (seconds)
                        double deltaTime = newTimestamp - lastWindowTimestamp;

                        //print
                        utilsScript.WriteToFile("\n[GPS Script]: Moving Window delta time: " + deltaTime + " seconds");

                        //speed calculation (m/s)
                        float speed = dist / (float)deltaTime;

                        //print
                        utilsScript.WriteToFile("\n[GPS Script]: Moving Window speed: " + speed + " m/s");

                        if (speedWindowList.Count() > 1)
                        {
                            // calculates the acceleration (deltaVelocity / deltaTime)
                            accelerationValue = ( speedWindowList.ElementAt(speedWindowList.Count() - 1) + speed )  / (float)deltaTime;
                            utilsScript.WriteToFile("\n[GPS Script]: Acceleration Value: " + accelerationValue + " m/s^2");
                        }

                        ////////////////////////////    Moving Window Algorithm verifications   ////////////////////////////////

                        //if user is fixed at a position and there are more than initialisingIterations GPS readings
                        if (speed < minWindowSpeed && windowGPScount > initialisingIterations || //speed is too low, so user is fixed
                            accelerationValue < minWindowAcceleration && windowGPScount > initialisingIterations) // acceleration is too low, so user is fixed
                        {
                            // same position, so no need to change the lastWindow's latitude and longitude values

                            //time average
                            double tmpTimestamp = (newTimestamp + lastWindowTimestamp) / 2f;
                            lastWindowTimestamp = tmpTimestamp;
                            
                            //print
                            utilsScript.WriteToFile("\n[GPS Script]: I Think the User Stoped Here!");

                            // maintain the old position on Unity, so no need to change the latitude and longitude values

                        }
                        // if the speed value is greater than the max value and there are more than initialisingIterations GPS readings
                        else if (speed > maxWindowSpeed && windowGPScount > initialisingIterations) 
                        {
                            utilsScript.WriteToFile("\n[GPS Script]: Speed is to High for a Normal Ambulation (3m/s)!");

                            // replace the last GPS reading for the average of the last and new GPS readings
                            RemoveLastGPSReadings(newlatitude, newlongitude, newTimestamp);
                        }
                        // if the acceleration value is greater than the max value and there are more than initialisingIterations GPS readings
                        else if (accelerationValue > maxWindowAcceleration && windowGPScount > initialisingIterations)
                        {
                            utilsScript.WriteToFile("\n[GPS Script]: Acceleration is to High for even a runner (Usain Bolt - 3.09m/s^2)!");

                            // the acceleration value is to high, discard the values
                            RemoveLastGPSReadings(newlatitude, newlongitude, newTimestamp);
                        }
                        // if everything ok with the GPS readings
                        else
                        {
                            //add distance value to the list
                            distanceWindowList.Add(dist);

                            //add speed value to list
                            speedWindowList.Add(speed);

                            // calculate the necessary averages of the moving window algorithm
                            CalculateAverageValues();

                            //update to the last GPS reading values
                            lastWindowLatitude = newlatitude;
                            lastWindowLongitude = newlongitude;
                            lastWindowTimestamp = newTimestamp;

                            // add new values to arrays
                            latitudeWindowList.Add(newlatitude);
                            longitudeWindowList.Add(newlongitude);
                            timestampsWindowList.Add(newTimestamp);

                            //print
                            utilsScript.WriteToFile("\n[GPS Script]: Added the GPS reading as a good one!");

                            //update count
                            windowGPScount++;
                            firstValues++;

                            // update the Unity general latitude and longitude values
                            latitude = lastWindowLatitude;
                            longitude = lastWindowLongitude;

                        } // end everything ok else  
                    }// end < distance if
                    // if the distance if more than the GPSmaxDifDistance meters discard the GPS reading
                    else
                    {
                        if (firstValues < 5)
                        {
                            // if it is the first 5 readings discard the last GPS readings and use the new ones
                            RemoveLastGPSReadingsFirstValues(newlatitude, newlongitude, newTimestamp);
                        }
                        // if not the first readings and the distance is greater than the GPSmaxDifDistance value
                        else
                        {
                            // discard the last GPS readings and use the average between the last and the new ones
                            RemoveLastGPSReadings(newlatitude, newlongitude, newTimestamp);
                        }// end else first values
                    }
                    //end else GPSmaxDistance

                }//end if difference lat and long

            }//end firstreadings else 



            ///////////////////////////////////////////////////////////////   move camera   ////////////////////////////

            XCamera = locationScript.LongitudeToX(longitude);
            ZCamera = locationScript.LatitudeToZ(latitude);

            if (firstCamera)
            {
                lastX = XCamera;
                lastZ = ZCamera;
                cameraContainer.transform.position = Vector3.Lerp(transform.position, new Vector3(XCamera, 0, ZCamera), Time.deltaTime * smooth);
                Debug.LogError("[GPS Script]: Camera started at (x - z): " + XCamera + " - " + ZCamera);
                firstCamera = false;
            }
            else
            {
                // calculate the difference between the new and last readings
                float difX = Mathf.Abs(XCamera - lastX);
                float difZ = Mathf.Abs(ZCamera - lastZ);

                // if it changes update the camera position in the virtual world
                if (difX > 0.1 || difZ > 0.1)
                {
                    cameraContainer.transform.position = Vector3.Lerp(transform.position, new Vector3(XCamera, 0, ZCamera), Time.deltaTime * smooth);
                    Debug.LogError("[GPS Script]: Camera moved to (x - z): " + XCamera + " - " + ZCamera);

                    //update last values
                    lastX = XCamera;
                    lastZ = ZCamera;
                }
            }


                /////////////////////////////////////////////////////////////////////////////////////////////////////

                //update text in camera
                coordinates.text = "Lat: " + Input.location.lastData.latitude.ToString() + "     Long: " + Input.location.lastData.longitude.ToString() +
                "     Altitude: " + Input.location.lastData.altitude.ToString() + "     Ver.Accuracy: " + Input.location.lastData.verticalAccuracy.ToString() +
                "\nHor.Accuracy: " + Input.location.lastData.horizontalAccuracy.ToString() + "     Timestamp: " + Input.location.lastData.timestamp.ToString();
            debugGPS.text = "Debug: GPS updated";

            //compass values updating
            //calculates the average of the 10 compass values
            if (!compassV)
            {
                if (compassCount > 9)
                {
                    compassV = true;
                    float sum = 0f;
                    for (int i = 0; i < compassValuesArray.Length; i++)
                    {
                        sum += compassValuesArray[i];
                    }
                    //North = 0 or 360 -- East = 90 -- South = 180 -- West = 270
                    float compassAverage = sum / compassValuesArray.Length;
                    Debug.LogWarning("[GPS Script]: compass average: " + compassAverage);
                    //rotate camera
                    cameraContainer.transform.Rotate(0, compassAverage, 0);
                }
                else
                {
                    //add compass values to array
                    compassValuesArray[compassCount] = Input.compass.trueHeading;
                    //Debug.LogWarning("[Server Connection]: last compass value: " + compassValuesArray[compassCount]);
                    compassCount++;
                }
            }
            else
            {
                //debugGPS.text = "Debug: User has not enabled GPS";
            }

        }
    }

    /// <summary>
    /// calculates the distance moving average, latitude and longitude moving average, speed moving average, and acceleration moving average
    /// </summary>
    public void CalculateAverageValues()
    {
        //distance moving average
        float distancesum = 0f;
        for (int i = 0; i < distanceWindowList.Count(); i++)
        {
            distancesum += distanceWindowList.ElementAt(i);
        }
        movingDistanceAverage = distancesum / distanceWindowList.Count();

        //print
        utilsScript.WriteToFile("\n\n[GPS Script]: Distance Moving Average: " + movingDistanceAverage.ToString("0.00") + " meters");

        // if there is at least one reading we can calculate the lat and long mobing average
        if (latitudeWindowList.Count() > 1)
        {
            // lat moving average
            float latsum = 0f;
            for (int i = 1; i < latitudeWindowList.Count(); i++)
            {
                latsum += Mathf.Abs(latitudeWindowList.ElementAt(i) - latitudeWindowList.ElementAt(i - 1));
            }
            movingLatitudeAverage = latsum / latitudeWindowList.Count();
            //print
            utilsScript.WriteToFile("\n[GPS Script]: Latitude Moving Average: " + movingLatitudeAverage.ToString("0.00000000"));

            // long moving average
            float longsum = 0f;
            for (int i = 1; i < longitudeWindowList.Count(); i++)
            {
                longsum += Mathf.Abs(longitudeWindowList.ElementAt(i) - longitudeWindowList.ElementAt(i - 1));
            }
            movingLongitudeAverage = longsum / longitudeWindowList.Count();
            //print
            utilsScript.WriteToFile("\n[GPS Script]: Longitude Moving Average: " + movingLongitudeAverage.ToString("0.00000000"));


            // if there is at least 2 speed values recorded we can calculate the speed average
            if (speedWindowList.Count() > 1)
            {
                //speed moving average
                float speedsum = 0f;
                for (int i = 0; i < speedWindowList.Count(); i++)
                {
                    speedsum += speedWindowList.ElementAt(i);
                }
                movingSpeedAverage = speedsum / speedWindowList.Count();
                //print
                utilsScript.WriteToFile("\n[GPS Script]: Speed Moving Average: " + movingSpeedAverage);

                // calculates the acceleration average
                float accelerationsum = 0f;
                for (int i = 1; i < speedWindowList.Count(); i++)
                {
                    accelerationsum += Mathf.Abs(speedWindowList.ElementAt(i) - speedWindowList.ElementAt(i - 1));
                }
                movingAccelerationAverage = accelerationsum / (speedWindowList.Count() - 1);
                //print
                utilsScript.WriteToFile("\n[GPS Script]: Acceleration Moving Average: " + movingAccelerationAverage.ToString("0.000") + " m/s^2");

            } //end speed if
        }
    }


    /// <summary>
    /// Removes the last GPS readings from the lists and set the average lat and long values. Uses the last update of the timestamp
    /// </summary>
    /// <param name="newlatitude"></param>
    /// <param name="newlongitude"></param>
    /// <param name="newTimestamp"></param>
    public void RemoveLastGPSReadings(float newlatitude, float newlongitude, double newTimestamp)
    {
        // the lat, long, and timestamp values are the average between them
        float tmpLat = (lastWindowLatitude + newlatitude) / 2f;
        float tmpLong = (lastWindowLongitude + newlongitude) / 2f;
        double tmpTimestamp = (newTimestamp + lastWindowTimestamp) / 2f;
        
        //update values
        lastWindowTimestamp = tmpTimestamp;
        lastWindowLatitude = tmpLat;
        lastWindowLongitude = tmpLong;

        //print
        utilsScript.WriteToFile("\n\n[GPS Script]: Discarding GPS readings: " + latitudeWindowList.ElementAt(latitudeWindowList.Count - 1) + " " +
            longitudeWindowList.ElementAt(longitudeWindowList.Count - 1));

        //remove the last readings 
        latitudeWindowList.RemoveAt(latitudeWindowList.Count - 1);
        longitudeWindowList.RemoveAt(longitudeWindowList.Count - 1);
        timestampsWindowList.RemoveAt(timestampsWindowList.Count - 1);

        // add the current new values to arrays, replacing the position of the removed ones
        latitudeWindowList.Add(tmpLat);
        longitudeWindowList.Add(tmpLong);
        timestampsWindowList.Add(tmpTimestamp);

        //print
        utilsScript.WriteToFile("\n[GPS Script]: Added the average of the last two GPS readings: " + tmpLat + " " +  tmpLong + " " + tmpLong + "\n");

        // update the Unity general latitude and longitude values
        latitude = tmpLat;
        longitude = tmpLong;

    }

    /// <summary>
    /// Removes the last GPS readings from the lists and set the new lat, long, and timestamp values (to use with the firstValues boolean).
    /// </summary>
    /// <param name="newlatitude"></param>
    /// <param name="newlongitude"></param>
    /// <param name="newTimestamp"></param>
    public void RemoveLastGPSReadingsFirstValues(float newlatitude, float newlongitude, double newTimestamp)
    {
        utilsScript.WriteToFile("\n\n[GPS Script]: Discarding GPS readings: " + latitudeWindowList.ElementAt(latitudeWindowList.Count - 1) +
                                    longitudeWindowList.ElementAt(longitudeWindowList.Count - 1) + timestampsWindowList.ElementAt(timestampsWindowList.Count - 1));

        //remove the last readings if it is in the first 5 ones
        latitudeWindowList.RemoveAt(latitudeWindowList.Count - 1);
        longitudeWindowList.RemoveAt(longitudeWindowList.Count - 1);
        timestampsWindowList.RemoveAt(timestampsWindowList.Count - 1);

        // add the current new values to arrays, replacing the position of the removed ones
        latitudeWindowList.Add(newlatitude);
        longitudeWindowList.Add(newlongitude);
        timestampsWindowList.Add(newTimestamp);

        //update last values on the instance variables
        lastWindowLatitude = newlatitude;
        lastWindowLongitude = newlongitude;
        lastWindowTimestamp = newTimestamp;

        utilsScript.WriteToFile("\n[GPS Script]: Added the current GPS readings: " + newlatitude + " " + newlongitude + " " + newTimestamp + "\n");

        // update count
        firstValues++;

        // update the Unity general latitude and longitude values
        latitude = lastWindowLatitude;
        longitude = lastWindowLongitude;

    }


    /// <summary>
    /// Starts the gps and the compass if the app is running in a mobile device
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartLocationService()
    {
        // if GPS is not enabled (only works in mobile devices. In pc always not working
        if (!Input.location.isEnabledByUser)
        {
            Debug.LogWarning("[GPS Script]: User has not enabled GPS");
        }
        else
        {
            // Start the localisation

            //compass
            Input.compass.enabled = true;

            //gps
            //Start(float desiredAccuracyInMeters = 10f, float updateDistanceInMeters = 10f) --> default -> Start(); 
            Input.location.Start(3f, 1f);

            //wait to the initialisation of the GPS functions
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            //if wait time expires
            if (maxWait <= 0)
            {
                Debug.Log("[GPS Script]:Time out");
                yield break;
            }

            //if it failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("[GPS Script]: Unable to determin device location");
            }
            //if it runs get lat and long
            else
            {
                gpsEnabled = true;
            }
        }
    }




    // old GPS

    ////gps values updating
    ////calculates the avreage of the 10 gps lat and long values
    //if (!gpsV)
    //{
    //    if (gpsCount > 9)
    //    {
    //        //latitude
    //        float sumlat = 0f;
    //        for (int i = 0; i < gpsValuesArrayLatitude.Length; i++)
    //        {
    //            sumlat += gpsValuesArrayLatitude[i];
    //        }
    //        //North = 0 or 360 -- East = 90 -- South = 180 -- West = 270
    //        float gpsAveragelat = sumlat / gpsValuesArrayLatitude.Length;
    //        Debug.LogWarning("[GPS Script]:GPS average lat: " + gpsAveragelat);
    //        latitude = gpsAveragelat;

    //        //long
    //        float sumlong = 0f;
    //        for (int i = 0; i < gpsValuesArrayLongitude.Length; i++)
    //        {
    //            sumlong += gpsValuesArrayLongitude[i];
    //        }
    //        //North = 0 or 360 -- East = 90 -- South = 180 -- West = 270
    //        float gpsAveragelong = sumlong / gpsValuesArrayLongitude.Length;
    //        Debug.LogWarning("[GPS Script]: GPS average long: " + gpsAveragelong);
    //        longitude = gpsAveragelong;

    //        gpsCount = 0;

    //        //move camera
    //        XCamera = locationScript.LongitudeToX(longitude);
    //        ZCamera = locationScript.LatitudeToZ(latitude);

    //        if (firstCamera)
    //        {
    //            lastX = XCamera;
    //            lastZ = ZCamera;
    //            cameraContainer.transform.position = Vector3.Lerp(transform.position, new Vector3(XCamera, 0, ZCamera), Time.deltaTime * smooth);
    //            Debug.LogError("[GPS Script]: Camera moved to: " + XCamera + " - " + ZCamera);
    //            firstCamera = false;
    //        }
    //        else
    //        {
    //            if(!XCamera.Equals(lastX) || !ZCamera.Equals(lastZ))
    //            {
    //                cameraContainer.transform.position = Vector3.Lerp(transform.position, new Vector3(XCamera, 0, ZCamera), Time.deltaTime * smooth);
    //                Debug.LogError("[GPS Script]: Camera moved to: " + XCamera + " - " + ZCamera);
    //                lastX = XCamera;
    //                lastZ = ZCamera;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        //add lat and long values to arrays
    //        gpsValuesArrayLatitude[gpsCount] = Input.location.lastData.latitude;
    //        gpsValuesArrayLongitude[gpsCount] = Input.location.lastData.longitude;
    //        gpsCount++;
    //    }
    //}
    //else
    //{
    //    //debugGPS.text = "Debug: User has not enabled GPS";
    //}

}
