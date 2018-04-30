using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BuildScene : MonoBehaviour {

    // script to access the functions to calculate distances
    public LocationHandler locationScript;

    //min and max distance to see the V.O.
    public float distance_threshold_min;
    public float distance_threshold_max;

    // gameobject arrays
    public GameObject[] trafficArray;
    public GameObject[] espirasArray;
    public GameObject[] crosswalksArray;


    //saves the objects receivd from the database
    public List<ServerObject> objectList;

    // create the gameObjects at position, differs the game object according to the different types of infrastructures
    private Text titleObj;
    public GameObject infrastructure_TrafficLight;
    public GameObject infrastructure_TrafficLight_upper;
    public GameObject infrastructure_Espira;
    public GameObject infrastructure_Crooswalk;
    public Transform infraPos;

    void Start () {

        //initialise arrays with the maximum of 100 V.O.
        trafficArray = new GameObject[100];
        espirasArray = new GameObject[100];
        crosswalksArray = new GameObject[100];

        distance_threshold_max = 20f;
        distance_threshold_min = 8f;

        //initialise the list of the server objects
        objectList = new List<ServerObject>();

    }
	
	// Update is called once per frame
	void Update () {
        //creates the scene's V.O.
        SceneCreation();
    }


    /// <summary>
    /// <para>This function creates the virtual objects according to the distance. </para>
    /// If the distande from the user to the stored infrastructure is less than distance_threshold_max meters and more than distance_threshold_min meters, it created the V.O.
    /// When the distance is more than distance_threshold_max meters and less than distance_threshold_min meters, the V.O is disabled.
    /// </summary>
    public void SceneCreation()
    {
        if (objectList.Count() != 0)
        {
            //for each object in the stored objects list
            foreach (ServerObject objectInList in objectList)
            {
                //if opbject is not already created
                if (!objectInList.created.Equals("yes"))
                {
                    float dist = 0f; ;
                    //traffic lights
                    if (!objectInList.traffic_light_id.Equals(0))
                    {
                        dist = locationScript.Location(objectInList.coordinatesX, objectInList.coordinatesY);
                        
                    }
                    //espiras
                    if (!objectInList.gis_espiras_id.Equals(0))
                    {
                        dist = locationScript.Location(objectInList.gis_espiras_coordinatesX, objectInList.gis_espiras_coordinatesY);

                    }
                    //crosswalk
                    if (!objectInList.gis_crosswalks_id.Equals(0))
                    {
                        dist = locationScript.Location(objectInList.gis_crosswalk_coordinatesX, objectInList.gis_crosswalk_coordinatesY);
                    }

                    //  create V.O
                    if (dist >= distance_threshold_min && dist <= distance_threshold_max)
                    {
                        //set created as true 
                        objectInList.created = "yes";

                        //delaration of the cartesian variables
                        float x = 0f;
                        float y = 0f;
                        float z = 0f;
                        string name = "";

                        //traffic lights
                        if (!objectInList.traffic_light_id.Equals(0))
                        {
                            z = locationScript.LatitudeToZ(objectInList.coordinatesX);
                            x = locationScript.LongitudeToX(objectInList.coordinatesY);
                            //y = 3f;
                            y = 0f;
                            Debug.LogWarning("Server Connection [Creating V.O.]:  Traffic Id: " + objectInList.traffic_light_id);

                            //set gameObject name
                            name = "TrafficLight" + objectInList.traffic_light_id;

                            GameObject signalType;

                            if (objectInList.traffic_light_id.Equals(5) || objectInList.traffic_light_id.Equals(6))
                            {
                                signalType = infrastructure_TrafficLight_upper;
                            }
                            else
                            {
                                signalType = infrastructure_TrafficLight;
                            }

                            //create object
                            GameObject trafficLight_gameObject = (GameObject)Instantiate(signalType, new Vector3(x, y, z), infraPos.rotation);

                            int orientation = objectInList.signal_Orientation;
                            Debug.Log("[Augmented Script]: Traffic Light Orientation: " + orientation);

                            //rotate trafficLight_gameObject
                            trafficLight_gameObject.transform.Rotate(0, orientation, 0);
                            //add trafficLight_gameObject name
                            trafficLight_gameObject.name = name;

                            //// put GIS info on the suface of the object
                            //titleObj = trafficLight_gameObject.GetComponentInChildren<Text>();
                            //titleObj.text = "Id: " + objectInList.traffic_light_id;

                            // add the V.O. to scene
                            trafficLight_gameObject.SetActive(true);

                            //add to array
                            trafficArray[objectInList.traffic_light_id] = trafficLight_gameObject;
                        }
                        //espiras
                        if (!objectInList.gis_espiras_id.Equals(0))
                        {
                            z = locationScript.LatitudeToZ(objectInList.gis_espiras_coordinatesX);
                            x = locationScript.LongitudeToX(objectInList.gis_espiras_coordinatesY);
                            Debug.LogWarning("Server Connection [Creating V.O.]:  Espiras Id: " + objectInList.gis_espiras_id);
                            name = "Espira" + objectInList.gis_espiras_id;

                            //create object
                            GameObject espira = (GameObject)Instantiate(infrastructure_Espira, new Vector3(x, y, z), infraPos.rotation);
                            espira.name = name;

                            // put GIS info on the suface of the object
                            titleObj = espira.GetComponentInChildren<Text>();
                            titleObj.text = "Espiras\n\nId: " + objectInList.gis_espiras_id;

                            // add the V.O. to scene
                            espira.SetActive(true);

                            //add to array
                            espirasArray[objectInList.gis_espiras_id] = espira;
                        }
                        //crosswalk
                        if (!objectInList.gis_crosswalks_id.Equals(0))
                        {
                            z = locationScript.LatitudeToZ(objectInList.gis_crosswalk_coordinatesX);
                            x = locationScript.LongitudeToX(objectInList.gis_crosswalk_coordinatesY);
                            Debug.LogWarning("Server Connection [Creating V.O.]:  Crosswalk Id: " + objectInList.gis_crosswalks_id);
                            name = "Crosswalk" + objectInList.gis_crosswalks_id;

                            //create object
                            GameObject crosswalk = (GameObject)Instantiate(infrastructure_Crooswalk, new Vector3(x, y, z), infraPos.rotation);
                            crosswalk.name = name;

                            // put GIS info on the suface of the object
                            titleObj = crosswalk.GetComponentInChildren<Text>();
                            titleObj.text = "Crosswalk\n\nId:" + objectInList.gis_crosswalks_id;

                            // add the V.O. to scene
                            crosswalk.SetActive(true);

                            //add to array
                            crosswalksArray[objectInList.gis_crosswalks_id] = crosswalk;
                        }
                    }
                    else
                    {
                        //Debug.Log("Already created." + objectInList.traffic_light_id + objectInList.gis_espiras_id + objectInList.gis_crosswalks_id);
                    }
                }
                //if gameobject already created
                else
                {
                    float dist = 0f; ;
                    //traffic lights
                    if (!objectInList.traffic_light_id.Equals(0))
                    {
                        dist = locationScript.Location(objectInList.coordinatesX, objectInList.coordinatesY);
                        //Debug.LogWarning("Server Connection [Already Created V.O.]:  " + dist + " meters - Traffic Id: " + objectInList.traffic_light_id);
                    }
                    //espiras
                    if (!objectInList.gis_espiras_id.Equals(0))
                    {
                        dist = locationScript.Location(objectInList.gis_espiras_coordinatesX, objectInList.gis_espiras_coordinatesY);
                        //Debug.LogWarning("Server Connection [Already Created V.O.]:  " + dist + " meters - Espiras Id: " + objectInList.gis_espiras_id);
                    }
                    //crosswalk
                    if (!objectInList.gis_crosswalks_id.Equals(0))
                    {
                        dist = locationScript.Location(objectInList.gis_crosswalk_coordinatesX, objectInList.gis_crosswalk_coordinatesY);
                        //Debug.LogWarning("Server Connection [Already Created V.O.]:  " + dist + " meters - Crosswalk Id: " + objectInList.gis_crosswalks_id);
                    }

                    if (dist < distance_threshold_min || dist > distance_threshold_max)
                    {
                        if (!objectInList.traffic_light_id.Equals(0))
                        {
                            Debug.LogWarning("Server Connection [Disabling V.O.]:  " + dist + " meters - Traffic Id: " + objectInList.traffic_light_id);
                            //destroy V.O.
                            Destroy(trafficArray[objectInList.traffic_light_id]);
                            //not created again
                            objectInList.created = "no";
                            Debug.LogError("Traffic Light Id: " + objectInList.traffic_light_id + " destroyed");
                        }
                        //espiras
                        if (!objectInList.gis_espiras_id.Equals(0))
                        {
                            Debug.LogWarning("Server Connection [Disabling V.O.]:  " + dist + " meters - Espiras Id: " + objectInList.gis_espiras_id);
                            //destroy V.O.
                            Destroy(espirasArray[objectInList.gis_espiras_id]);
                            //not created again
                            objectInList.created = "no";
                            Debug.LogError("Espira Id: " + objectInList.gis_espiras_id + " destroyed");
                        }
                        //crosswalk
                        if (!objectInList.gis_crosswalks_id.Equals(0))
                        {
                            Debug.LogWarning("Server Connection [Disabling V.O.]:  " + dist + " meters - Crosswalk Id: " + objectInList.gis_crosswalks_id);
                            //destroy V.O.
                            Destroy(crosswalksArray[objectInList.gis_crosswalks_id]);
                            //not created again
                            objectInList.created = "no";
                            Debug.LogError("Crosswalk Id: " + objectInList.gis_crosswalks_id + " destroyed");
                        }

                    }

                }
            }

        }
    }


}
