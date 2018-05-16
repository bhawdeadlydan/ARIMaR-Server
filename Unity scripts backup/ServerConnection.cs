using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ServerConnection : MonoBehaviour
{
    //connecting to buildScene script
    public BuildScene buildSceneScript;

    //ip to connect with the server
    public string localIP = "192.168.3.90";

    //booleans
    private bool canAdd;
    private bool serverConnectionStarts;

    //canvas
    public Text serverData;


    /// <summary>
    /// Initialises the values and repeatedly calls the functions to get the data and display them.
    /// </summary>
    void Start()
    {
        canAdd = false;
        serverConnectionStarts = false;

        //call function every 5 seconds, starts after 3 seconds
        InvokeRepeating("CallConnectionServices", 3.0f, 5.0f);
    }


    /// <summary>
    /// call all the coroutines to get the database data from the server
    /// </summary>
    public void CallConnectionServices()
    {
        StartCoroutine(GetTrafficAround(GPS.Instance.latitude, GPS.Instance.longitude));
        StartCoroutine(GetEspirasAround(GPS.Instance.latitude, GPS.Instance.longitude));
        StartCoroutine(GetCrosswalksAround(GPS.Instance.latitude, GPS.Instance.longitude));
        serverConnectionStarts = true;
    }

    /// <summary>
    /// Gets the traffic light from the server
    /// </summary>
    /// <param name="coordx">current latitude</param>
    /// <param name="coordy">current longitude</param>
    /// <returns></returns>
    IEnumerator GetTrafficAround(float coordx, float coordy)
    {
        //url connection
        string getWayUrl = "http://" + localIP + ":8080/find/traffic-lights/two/";
        //string getWayUrl = "http://127.0.0.1:8080/find/traffic-lights/two/";
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

                            //verifies if already created or not, if not 
                            AddOrNot(element);
                            //add object to list of received objects 
                            if (canAdd)
                            {
                                element.created = "no";
                                buildSceneScript.objectList.Add(element);
                                Debug.Log("Added traffic light " + element.traffic_light_id + " to the objectList");
                            }

                        }
                        serverData.text = "Server: received something";
                    }
                }
            }
        }

    }


    /// <summary>
    /// Gets the Espiras from the server
    /// </summary>
    /// <param name="coordx">current latitude</param>
    /// <param name="coordy">current longitude</param>
    /// <returns></returns>
    IEnumerator GetEspirasAround(float coordx, float coordy)
    {
        //double coordx = -960078.26;
        //double coordy = 5035965.30;
        //url connection
        string getWayUrl = "http://" + localIP + ":8080/find/gis-espiras/two/";
        //string getWayUrl = "http://127.0.0.1:8080/find/gis-espiras/two/";
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
                            //verifies if already created or not
                            AddOrNot(element);

                            //add object to list and create the instance
                            if (canAdd)
                            {
                                element.created = "no";
                                buildSceneScript.objectList.Add(element);
                                Debug.Log("Added espira " + element.gis_espiras_id + " to the objectList");
                            }
                        }
                        serverData.text = "Server: received something";
                    }
                }
            }
        }

    }


    /// <summary>
    /// Gets the Crosswalks from the server
    /// </summary>
    /// <param name="coordx">current latitude</param>
    /// <param name="coordy">current longitude</param>
    /// <returns></returns>
    IEnumerator GetCrosswalksAround(float coordx, float coordy)
    {
        //double coordx = -960078.26;
        //double coordy = 5035965.30;
        //url connection
        string getWayUrl = "http://" + localIP + ":8080/find/gis-crosswalks/two/";
        //string getWayUrl = "http://127.0.0.1:8080/find/gis-crosswalks/two/";
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

                            //verifies if already created or not
                            AddOrNot(element);

                            //add object to list and create the instance
                            if (canAdd)
                            {
                                element.created = "no";
                                buildSceneScript.objectList.Add(element);
                                Debug.Log("Added crosswalk " + element.gis_crosswalks_id + " to the objectList");
                            }
                        }

                        serverData.text = "Server: received something";
                    }
                }
            }
        }

    }


    /// <summary>
    /// Sets the canAdd boolean to true if the serverObject doesn't already exists in the List objectsList
    /// </summary>
    /// <param name="element">object from the server</param>
    public void AddOrNot(ServerObject element)
    {
        //if list not empty
        if (buildSceneScript.objectList.Count() != 0)
        {
            // for each object in the objectlist
            foreach (ServerObject ob in buildSceneScript.objectList)
            {
                //verify if already exists
                //traffic lights
                if (element.traffic_light_id.Equals(ob.traffic_light_id) && !element.traffic_light_id.Equals(0))
                {
                    Debug.LogError("ID igual");
                    canAdd = false;
                    break;
                }
                //espiras
                if (element.gis_espiras_id.Equals(ob.gis_espiras_id) && !element.gis_espiras_id.Equals(0))
                {
                    Debug.LogError("ID igual");
                    canAdd = false;
                    break;
                }
                //crosswalks
                if (element.gis_crosswalks_id.Equals(ob.gis_crosswalks_id) && !element.gis_crosswalks_id.Equals(0))
                {
                    Debug.LogError("ID igual");
                    canAdd = false;
                    break;
                }
                // if it has not been already stored 
                else
                {
                    canAdd = true;
                }
            }
        }
        else //if list is empty
        {
            canAdd = true;
        }
    }



}