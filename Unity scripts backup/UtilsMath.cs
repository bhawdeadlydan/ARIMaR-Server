using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class UtilsMath : MonoBehaviour
{
    private string gpsFilePath;

    private void Start()
    {
        gpsFilePath = Application.persistentDataPath + "/logFilesGPSUnity.txt";

        // if file exists
        if (File.Exists(gpsFilePath))
        {
            //delete file
            try
            {
                File.Delete(gpsFilePath);
                Debug.Log("[Utils Script]: GPS File Log Deleted Successfully!");
            }
            catch (System.Exception e)
            {
                Debug.LogError("[Utils Script]: Cannot delete GPS File Log - Exception: " + e);
            }
        }
    }

    /// <summary>
    /// calculates distance between two sets of coordinates, taking into account the curvature of the earth. Haversine formula
    /// </summary>
    /// <param name="lat1">latitude point1</param>
    /// <param name="lon1">longitude point1</param>
    /// <param name="lat2">latitude point2</param>
    /// <param name="lon2">longitude point2</param>
    /// <returns>distance in meters between the two points</returns>
    public static double CalculateDistance(float lat1, float lon1, float lat2, float lon2)
    {
        float R = 6378.137f;

        float dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        float dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;

        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
          Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
          Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);

        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        double distance = R * c;

        distance = distance * 1000f; // meters 

        return distance;
    }



    /// <summary>
    /// <para> Writes the string message into the logFileUnity.txt in the internal storage\android\data\com.armis.arimarn\files\</para>
    /// Writes a '\n' in the end of each message
    /// </summary>
    /// <param name="message">String to print in the file</param>
    public void WriteToFile(string message)
    {
        try
        {
            //create the stream writer to the specific file
            StreamWriter fileWriter = new StreamWriter(gpsFilePath, true);
            
            //write the string into the file
            fileWriter.Write(message);

            // close the Stream Writer
            fileWriter.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError("[Utils Script]: Cannot write in the GPS File Log - Exception: " + e);
        }

    }



}

