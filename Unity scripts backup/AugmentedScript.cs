using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AugmentedScript : MonoBehaviour
{
    // serverconnection script
    public ServerConnection serverConnectionScript;

    //booleans
    public bool selected;

    //strings
    private string nameID = "";

    //canvas declaration
    public GameObject canvas;
    private Text canvasText;

    //server object declaration
    private ServerObject voObject;

    void Start()
    {
        selected = false;
    }

 

    /// <summary>
    /// selects the V.O. that the user pressed and shows up the BIM info in a canvas, uses the ohter coroutines to it.
    /// </summary>
    void OnMouseDown()
    {
            nameID = this.name;

            //traffic light
            if (nameID.Length.Equals(13) && !selected)
            {
                selected = true;
                string trafficId = nameID.Substring(nameID.Length - 1, 1);
                Debug.LogWarning("[Augmented Script]: Pressed V.O. : Traffic light id: " + trafficId);
                int newID = Int32.Parse(trafficId);
                StartCoroutine(GetTrafficLight(newID));
            }
            //espiras
            if (nameID.Length.Equals(7) && !selected)
            {
                string espiraId = nameID.Substring(nameID.Length - 1, 1);
                Debug.LogWarning("[Augmented Script]: Pressed V.O. : Espira light id: " + espiraId);
                int newID = Int32.Parse(espiraId);
                StartCoroutine(GetEspiras(newID));
            }
            //crosswalk
            if (nameID.Length.Equals(10) && !selected)
            {
                string crosswalkId = nameID.Substring(nameID.Length - 1, 1);
                Debug.LogWarning("[Augmented Script]: Pressed V.O. : Crosswalk light id: " + crosswalkId);
                int newID = Int32.Parse(crosswalkId);
                StartCoroutine(GetCrosswalks(newID));
            }
    }


    /// <summary>
    /// gets the BIM data from the server about a given traffic light id. Also builds the canvas with the info and display it 
    /// </summary>
    /// <param name="id">traffic light id</param>
    /// <returns>when the user presses again the screen, the canvas is destroyed</returns>
    IEnumerator GetTrafficLight(int id)
    {
        //instanciate Canvas
        GameObject newCanvas = (GameObject)Instantiate(canvas, new Vector3(0, 0, 0), Quaternion.identity);
        newCanvas.name = "TlCanvas" + id;

        //update Canvas text
        canvasText = newCanvas.GetComponentInChildren<Text>();
        canvasText.text = "Waiting For BIM Data. Connecting to Server...";
        newCanvas.SetActive(true);

        //url connection
        string getWayUrl = "http://" + serverConnectionScript.localIP + ":8080/bim/find/traffic-light?id=";
        string request = getWayUrl + id.ToString();

        //get request
        using (UnityWebRequest wayRequest = UnityWebRequest.Get(request))
        {
            yield return wayRequest.Send();
            //if any error
            if (wayRequest.isNetworkError || wayRequest.isHttpError)
            {
                //serverData.text = "Server:  Cannot connect to the destination host. Verify your connection, please.";
                Debug.Log(wayRequest.error);
                Destroy(newCanvas);
            }
            else
            {
                if (wayRequest.isDone)
                {
                    //get data to string
                    string jsonResult = System.Text.Encoding.UTF8.GetString(wayRequest.downloadHandler.data);
                    //Debug.Log(jsonResult);
                    if (jsonResult.Equals("null"))
                    {
                        Debug.Log("[Augmented Script]: Nothing received (traffic light id)");
                    }
                    else
                    {
                        //getting json data to object from server
                        voObject = JsonUtility.FromJson<ServerObject>(jsonResult); // string json data to object
                        //Debug.Log("feu: " + voObject.feu + " tys " + voObject.tys + " controller " + voObject.tl_Traffic_controller_id);

                        //update Canvas text
                        canvasText = newCanvas.GetComponentInChildren<Text>();
                        canvasText.text = "Traffic Light \n\n\nID: " + voObject.traffic_light_id + "     Feu: " + voObject.feu + "     Tys: " + voObject.tys + 
                            "     Latitude: " + voObject.coordinatesX + "     Longitude: " + voObject.coordinatesY + 
                            "\n\nIntersection ID: " + voObject.bim_intersection_id + "    Intersection name: " + voObject.bim_intersection_description +
                            "\n\nTL Group ID: " + voObject.tl_group_id + "    TL Step Group ID: " + voObject.tl_step_group_id + 
                            "    TL Step ID: " + voObject.tl_step_id + "    TL Step Value: " + voObject.step_value + "\n\nTL Max Time: " + voObject.max_step_time + 
                            "     TL Plan Value: " + voObject.plan_value + "     Plan Duration: " + voObject.duration;
                       

                        // wait until touch to destroy canvas
                        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                        Destroy(newCanvas);
                        
                        // allow open the same V.O.'s canvas again 
                        selected = false;
                    }
                }
                // if the request is not done. wait 10 seconds and destroy the canvas whrn click on the screen
                else
                {
                    yield return new WaitForSeconds(5);
                    //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    Destroy(newCanvas);
                }

            }
        }
    }


    /// <summary>
    /// gets the BIM data from the server about a given espiras id. Also builds the canvas with the info and display it 
    /// </summary>
    /// <param name="id">espiras id</param>
    /// <returns>when the user presses again again the screen, the canvas is destroyed</returns>
    IEnumerator GetEspiras(int id)
    {
        //instanciate Canvas
        GameObject newCanvas = (GameObject)Instantiate(canvas, new Vector3(0, 0, 0), Quaternion.identity);
        newCanvas.name = "TlCanvas" + id;

        //update Canvas text
        canvasText = newCanvas.GetComponentInChildren<Text>();
        canvasText.text = "Waiting For BIM Data. Connecting to Server...";
        newCanvas.SetActive(true);

        //url connection
        string getWayUrl = "http://" + serverConnectionScript.localIP + ":8080/bim/find/bim-espiras?id=";
        string request = getWayUrl + id.ToString();

        //get request
        using (UnityWebRequest wayRequest = UnityWebRequest.Get(request))
        {
            yield return wayRequest.Send();
            //if any error
            if (wayRequest.isNetworkError || wayRequest.isHttpError)
            {
                //serverData.text = "Server:  Cannot connect to the destination host. Verify your connection, please.";
                Debug.Log(wayRequest.error);
                Destroy(newCanvas);
            }
            else
            {
                if (wayRequest.isDone)
                {
                    //get data to string
                    string jsonResult = System.Text.Encoding.UTF8.GetString(wayRequest.downloadHandler.data);
                    //Debug.Log(jsonResult);
                    if (jsonResult.Equals("null"))
                    {
                        Debug.Log("[Augmented Script]: Nothing received (Espiras id)");
                    }
                    else
                    {
                        //getting json data to object from server
                        voObject = JsonUtility.FromJson<ServerObject>(jsonResult); // string json data to object
                        //Debug.Log("material: " + voObject.bim_espiras_material_id);

                        //update Canvas text
                        canvasText = newCanvas.GetComponentInChildren<Text>();
                        canvasText.text = "Espira \nID: " + voObject.bim_espiras_id + "\nIntersection: " + voObject.bim_espiras_intersection_id +
                            "\nMaterial: " + voObject.bim_espiras_material_id + "\nTipologia: " + voObject.bim_espiras_tipologia;

                        // wait 5 seconds to destroy canvas
                        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                        Destroy(newCanvas);
                        // allow open the same V.O.'s canvas again 
                        selected = false;
                    }
                }
                // if the request is not done. wait 10 seconds and destroy the canvas whrn click on the screen
                else
                {
                    yield return new WaitForSeconds(5);
                    //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    Destroy(newCanvas);
                }

            }
        }
    }


    /// <summary>
    /// gets the BIM data from the server about a given crosswalk id. Also builds the canvas with the info and display it 
    /// </summary>
    /// <param name="id">crosswalk id</param>
    /// <returns>when the user presses again again the screen, the canvas is destroyed</returns>
    IEnumerator GetCrosswalks(int id)
    {
        //instanciate Canvas
        GameObject newCanvas = (GameObject)Instantiate(canvas, new Vector3(0, 0, 0), Quaternion.identity);
        newCanvas.name = "TlCanvas" + id;

        //update Canvas text
        canvasText = newCanvas.GetComponentInChildren<Text>();
        canvasText.text = "Waiting For BIM Data. Connecting to Server...";
        newCanvas.SetActive(true);

                //url connection
        string getWayUrl = "http://" + serverConnectionScript.localIP + ":8080/bim/find/bim-crosswalks?id=";
        string request = getWayUrl + id.ToString();

        //get request
        using (UnityWebRequest wayRequest = UnityWebRequest.Get(request))
        {
            yield return wayRequest.Send();
            //if any error
            if (wayRequest.isNetworkError || wayRequest.isHttpError)
            {
                //serverData.text = "Server:  Cannot connect to the destination host. Verify your connection, please.";
                Debug.Log(wayRequest.error);
                Destroy(newCanvas);
            }

            else
            {
                if (wayRequest.isDone)
                {
                    //get data to string
                    string jsonResult = System.Text.Encoding.UTF8.GetString(wayRequest.downloadHandler.data);
                    //Debug.Log(jsonResult);
                    if (jsonResult.Equals("null"))
                    {
                        Debug.Log("[Augmented Script]: Nothing received (Crosswalks ID)");
                    }
                    else
                    {
                        //getting json data to object from server
                        voObject = JsonUtility.FromJson<ServerObject>(jsonResult); // string json data to object
                        //Debug.Log("feu: " + voObject.feu + " tys " + voObject.tys + " controller " + voObject.tl_Traffic_controller_id);

                        //update Canvas text
                        canvasText = newCanvas.GetComponentInChildren<Text>();
                        canvasText.text = "Crosswalk \nID: " + voObject.bim_crosswalks_id + "\nIntersection: " + voObject.bim_crosswalks_intersection_id +
                            "\nMaterial: " + voObject.bim_crosswalks_material_id;

                        // wait touch to destroy canvas
                        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                        Destroy(newCanvas);
                        // allow open the same V.O.'s canvas again 
                        selected = false;
                    }
                }
                // if the request is not done. wait 10 seconds and destroy the canvas whrn click on the screen
                else
                {
                    yield return new WaitForSeconds(5);
                    //yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    Destroy(newCanvas);
                }
            }
        }
    }


}
