using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class LocationHandler : MonoBehaviour
{
   
    private float currentLongitude;
    private float currentLatitude;

    private double distance;



    /// <summary>
    /// Calculates the distancs between two coordinates using an external formula. (Haversine)
    /// </summary>
    /// <param name="infraLatitude">Latitude of the infrastructure</param>
    /// <param name="infraLongitude">Longitude of the infrastructure</param>
    /// <returns></returns>
    public float Location(float infraLatitude, float infraLongitude)
    {
        //overwrite current lat and lon everytime
        currentLatitude = GPS.Instance.latitude;
        currentLongitude = GPS.Instance.longitude;

        //calculate the distance between where the player was when the app started and where they are now.
        //Debug.LogWarning("[Location Handler]: lat and long: " + currentLatitude + " - " + currentLongitude);
        distance = UtilsMath.CalculateDistance(GPS.Instance.latitude, GPS.Instance.longitude, infraLatitude, infraLongitude);
        float distanceFloat = (float)(Math.Round((double)distance, 2));

        return distanceFloat;
    }


    /// <summary>
    /// Moving window distance calculator. returns the distance between two coordinates given their lat and long values
    /// </summary>
    /// <param name="latitude1">Latitude Point1</param>
    /// <param name="longitude2">Longitude Point1</param>
    /// <param name="latitude3">Latitude Point2</param>
    /// <param name="longitude4">Longitude Point2</param>
    /// <returns></returns>
    public float DistanceWindow(float latitude1, float longitude2, float latitude3, float longitude4)
    {
        
        distance = UtilsMath.CalculateDistance(latitude1, longitude2, latitude3, longitude4);
        float distanceFloat = (float)(Math.Round((double)distance, 2));

        return distanceFloat;
    }


    /// <summary>
    /// maps the latitude into Z axis coordinates
    /// </summary>
    /// <param name="lat">point's latitude</param>
    /// <returns>Z coordinates</returns>
    public float LatitudeToZ(double lat)
    {
        float deltaLatitude = Mathf.Abs(((float)lat - 41.159400f)) * 111041.16f; // .1622276;

        return deltaLatitude;
    }


    /// <summary>
    /// maps the longitude into x axis coordinates
    /// </summary>
    /// <param name="lon">point's longitude</param>
    /// <returns>X coordinates</returns>
    public float LongitudeToX(double lon)
    {
        float deltaLongitude = Mathf.Abs(((float)lon - (-8.625065f))) * 83729.44f; // .433272;

        return deltaLongitude;
    }


}
