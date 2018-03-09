using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AugmentedScript : MonoBehaviour
{
    private float startLatitude;
    private float startLongitude;
    private float currentLongitude;
    private float currentLatitude;

    private GameObject distanceTextObject;
    private double distance;

    private bool startValues = true;

    private Vector3 targetPosition;
    private Vector3 startPosition;

    private float speed = 0.1f;

    private bool firstTimeGPS = true;


    void Start()
    {
        //get distance text reference
        distanceTextObject = GameObject.FindGameObjectWithTag("distanceText");
        //initialize target and original position
        targetPosition = transform.position;
        startPosition = transform.position;

    }

    void Update()
    {
        if (GPS.Instance.gpsEnabled && firstTimeGPS)
        {
            //start GetCoordinate() function 
            GetCoordinates();
            firstTimeGPS = false;
        }
        
        //overwrite current lat and lon everytime
        currentLatitude = GPS.Instance.latitude;
        currentLongitude = GPS.Instance.longitude;

        //calculate the distance between where the player was when the app started and where they are now.
        CalculateDiff(startLatitude, startLongitude, currentLatitude, currentLongitude);

        //linearly interpolate from current position to target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
        distanceTextObject.GetComponent<Text>().text = "UFO's Position : " + targetPosition + "  Distance: " + distance +
            "\nlat - long: " +currentLatitude + " - " + currentLongitude;

        //rotate by 1 degree about the y axis every frame
        transform.eulerAngles += new Vector3(0, 1f, 0);

    }


    public void GetCoordinates()
    {

        if (startValues)
        {
            startLatitude = GPS.Instance.latitude;
            startLongitude = GPS.Instance.longitude;
            startValues = false;
            Debug.Log("lat and long: " + startLatitude + "   " + startLongitude);
        }
    }

    //calculates distance between two sets of coordinates, taking into account the curvature of the earth.
    //Haversine formula
    public void CalculateDiff(float lat1, float lon1, float lat2, float lon2)
    {

        float R = 6378.137f; // Radius of earth in KM
        //calculates delta latitude and delta longitude
        float dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        float dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;


        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
          Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
          Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);


        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        distance = R * c;


        distance = distance * 1000f; // meters i guess
        //set the distance text on the canvas
        distanceTextObject.GetComponent<Text>().text = " Distance: " + distance + " lat: " + lat2 + " long: " + lon2;

        //convert distance from double to float
        float distanceFloat = (float)(Math.Round((double)distance, 2));

        //set the target position of the ufo, this is where we lerp to in the update function
        targetPosition = startPosition - new Vector3(0, 0, distanceFloat*15); //multiply here for a k if it is necessary

        

    }


}
