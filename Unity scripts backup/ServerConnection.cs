using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ServerConnection : MonoBehaviour
{
    // Use this for initialization
    private double coordinatesx;
    private double coordinatesy;

    public Text serverData;

    void Start()
    {

        //StartCoroutine(GetTrafficLight());
        StartCoroutine(GetTrafficAround());
        StartCoroutine(GetEspirasAround());
        StartCoroutine(GetCrosswalksAround());
    }

    // Update is called once per frame
    void Update()
    {
        //coordinatesx = GPS.Instance.latitude;
        //coordinatesy = GPS.Instance.longitude;

    }

    // to use in update (i guess it will work well)
    public void callConnectionServices()
    {
        //StartCoroutine(GetTrafficLight());
        StartCoroutine(GetTrafficAround());
        StartCoroutine(GetEspirasAround());
        StartCoroutine(GetCrosswalksAround());
    }

       IEnumerator GetTrafficAround()
    {
       //change to GPS coordinates
        double coordx = -960078.26;
        double coordy = 5035965.30;
        //url connection
        string getWayUrl = "http://127.0.0.1:8080/find/traffic-lights/two/";
        string request = getWayUrl + coordx.ToString() + "/?coordy=" + coordy.ToString();
        
        //get request
        using (UnityWebRequest wayRequest = UnityWebRequest.Get(request))
        {
            yield return wayRequest.Send();
            //if any error
            if (wayRequest.isNetworkError || wayRequest.isHttpError)
            {
                serverData.text = "Server:  Cannot connect to the destination host. Verify your connection, please.";
                Debug.Log(wayRequest.error);
            }
            else
            {
                if (wayRequest.isDone)
                {
                    //get data to string
                    string jsonResult = System.Text.Encoding.UTF8.GetString(wayRequest.downloadHandler.data);
                    // Debug.Log(jsonResult);

                    if (jsonResult.Equals("null"))
                    {
                        Debug.Log("Nothing received (traffic light)");
                    }
                    else
                    {
                        //getting json data to object from server
                        //hack to work with the JsonHelper class
                        string value = "{\"Items\":" + jsonResult + "}";

                        //print the received objects
                        ServerObject[] jsonObject = JsonHandler.FromJson<ServerObject>(value); // string json data to object
                        foreach (ServerObject element in jsonObject)
                        {
                            Debug.Log("traffic light ID: " + element.traffic_light_id + " feu: " + element.feu + " tys: " + element.tys +
                                " Controller_Id: " + element.tl_Traffic_controller_id + " coordx: " + element.coordinatesX + " coordy: " + element.coordinatesY);
                        }
                        serverData.text = "Server: received something";
                    }
                }
            }
        }

    }

    IEnumerator GetEspirasAround()
    {
        double coordx = -960078.26;
        double coordy = 5035965.30;
        //url connection
        string getWayUrl = "http://127.0.0.1:8080/find/gis-espiras/two/";
        string request = getWayUrl + coordx.ToString() + "/?coordy=" + coordy.ToString();


        //get request
        using (UnityWebRequest wayRequest = UnityWebRequest.Get(request))
        {
            yield return wayRequest.Send();
            //if any error
            if (wayRequest.isNetworkError || wayRequest.isHttpError)
            {
                serverData.text = "Server:  Cannot connect to the destination host. Verify your connection, please.";
                Debug.Log(wayRequest.error);
            }
            else
            {
                if (wayRequest.isDone)
                {
                    //get data to string
                    string jsonResult = System.Text.Encoding.UTF8.GetString(wayRequest.downloadHandler.data);
                    // Debug.Log(jsonResult);

                    if (jsonResult.Equals("null"))
                    {
                        Debug.Log("Nothing received (espiras)");
                    }
                    else
                    {
                        //getting json data to object from server
                        //hack to work with the JsonHelper class
                        string value = "{\"Items\":" + jsonResult + "}";

                        //print the received objects
                        ServerObject[] jsonObject = JsonHandler.FromJson<ServerObject>(value); // string json data to object
                        foreach (ServerObject element in jsonObject)
                        {
                            Debug.Log("Espira ID: " + element.gis_espiras_id + " intersection: " + element.gis_espiras_intersection_id +
                                " coordx: " + element.gis_espiras_coordinatesX + " coordy: " + element.gis_espiras_coordinatesY);

                        }
                        serverData.text = "Server: received something";
                    }
                }
            }
        }

    }

    IEnumerator GetCrosswalksAround()
    {
        double coordx = -960078.26;
        double coordy = 5035965.30;
        //url connection
        string getWayUrl = "http://127.0.0.1:8080/find/gis-crosswalks/two/";
        string request = getWayUrl + coordx.ToString() + "/?coordy=" + coordy.ToString();
        
        //get request
        using (UnityWebRequest wayRequest = UnityWebRequest.Get(request))
        {
            yield return wayRequest.Send();
            //if any error
            if (wayRequest.isNetworkError || wayRequest.isHttpError)
            {
                serverData.text = "Server:  Cannot connect to the destination host. Verify your connection, please.";
                Debug.Log(wayRequest.error);
            }
            else
            {
                if (wayRequest.isDone)
                {
                    //get data to string
                    string jsonResult = System.Text.Encoding.UTF8.GetString(wayRequest.downloadHandler.data);
                    // Debug.Log(jsonResult);
                    if (jsonResult.Equals("null"))
                    {
                        Debug.Log("Nothing received (crosswalk)");
                    }
                    else
                    {
                        //getting json data to object from server
                        //hack to work with the JsonHelper class
                        string value = "{\"Items\":" + jsonResult + "}";

                        //print the received objects
                        ServerObject[] jsonObject = JsonHandler.FromJson<ServerObject>(value); // string json data to object
                        foreach (ServerObject element in jsonObject)
                        {
                            Debug.Log("Crosswalk ID: " + element.gis_crosswalks_id + " intersection: " + element.gis_crosswalks_intersection_id +
                                " coordx: " + element.gis_crosswalk_coordinatesX + " coordy: " + element.gis_crosswalk_coordinatesY);
                        }
                       
                        serverData.text = "Server: received something";
                    }
                }
            }
        }

    }

    IEnumerator GetTrafficLight()
    {
        //url connection
        string getWayUrl = "http://127.0.0.1:8080/bim/find/traffic-light?id=";
        int id = 2;
        string request = getWayUrl + id.ToString();


        //get request
        using (UnityWebRequest wayRequest = UnityWebRequest.Get(request))
        {
            yield return wayRequest.Send();
            //if any error
            if (wayRequest.isNetworkError || wayRequest.isHttpError)
            {
                serverData.text = "Server:  Cannot connect to the destination host. Verify your connection, please.";
                Debug.Log(wayRequest.error);
            }
            else
            {
                if (wayRequest.isDone)
                {
                    //get data to string
                    string jsonResult = System.Text.Encoding.UTF8.GetString(wayRequest.downloadHandler.data);
                    // Debug.Log(jsonResult);
                    if (jsonResult.Equals("null"))
                    {
                        Debug.Log("Nothing received (traffic light id)");
                    }
                    else
                    {
                        //getting json data to object from server
                        ServerObject jsonObject = JsonUtility.FromJson<ServerObject>(jsonResult); // string json data to object
                        Debug.Log("Id: " + jsonObject.tl_Traffic_controller_id + " coordX " + jsonObject.coordinatesX + " CoordY " + jsonObject.coordinatesY);

                        serverData.text = "Server: " + "Id: " + jsonObject.tl_Traffic_controller_id + " coordX " + jsonObject.coordinatesX + " CoordY " + jsonObject.coordinatesY;
                    }
                }
            }
        }

    }





}