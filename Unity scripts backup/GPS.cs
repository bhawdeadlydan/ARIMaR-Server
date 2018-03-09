using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;


public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }
    public float latitude;
    public float longitude;
    public float altitude;
    public float horizontalAccuracy;
    public float altitudeAccuracy;
    public double timestamp;

    public Text coordinates;
    public Text debugGPS;

    public bool gpsEnabled;


    private void Start()
    {
        gpsEnabled = false;
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
        debugGPS.text = "Debug: Application Started";
    }



    private void Update()
    {
        if (gpsEnabled)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            altitude = Input.location.lastData.altitude;
            horizontalAccuracy = Input.location.lastData.horizontalAccuracy;
            timestamp = Input.location.lastData.timestamp;
            altitudeAccuracy = Input.location.lastData.verticalAccuracy;

            //update text in camera
            coordinates.text = "Lat: " + Instance.latitude.ToString() + "     Long: " + Instance.longitude.ToString() +
                "     Altitude: " + Instance.altitude.ToString() + "\nHor.Accuracy: " + Instance.horizontalAccuracy.ToString() +
                "     Ver.Accuracy: " + Instance.altitudeAccuracy.ToString() + "     Timestamp: " + Instance.timestamp.ToString();
            debugGPS.text = "Debug: GPS updated";
        }
        else
        {
            debugGPS.text = "Debug: User has not enabled GPS";
        }
    }

    private IEnumerator StartLocationService()
    {
        // if GPS is not enabled (only works in mobile devices. In pc always not working
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Debug: User has not enabled GPS");
        }

        else
        {
            // Start the localisation
            /*
             * Start(float desiredAccuracyInMeters = 10f, float updateDistanceInMeters = 10f) --> default -> Start(); 
             */
            Input.location.Start(20f, 1f);


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
                Debug.Log("Time out");
                yield break;
            }

            //if it failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determin device location");

            }
            //if it runs get lat and long
            else
            {
                gpsEnabled = true;
                latitude = Input.location.lastData.latitude;
                longitude = Input.location.lastData.longitude;
                altitude = Input.location.lastData.altitude;
                horizontalAccuracy = Input.location.lastData.horizontalAccuracy;
                timestamp = Input.location.lastData.timestamp;
                altitudeAccuracy = Input.location.lastData.verticalAccuracy;
             
            }
        }



    }

}
