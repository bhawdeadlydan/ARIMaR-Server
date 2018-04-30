using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class for handling json objects
/// </summary>
public class JsonHandler : MonoBehaviour
{
    /// <summary>
    /// gets from json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    /// <summary>
    /// COnverts to json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    /// <summary>
    /// Converts to json in a pretty way
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="prettyPrint"></param>
    /// <returns></returns>
    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

/// <summary>
/// <para>Class for the server objects instance variables</para>
/// The instance variables names must be spelt exactly as in the DTO object class (Java RESTful server)
/// </summary>
[System.Serializable]
public class ServerObject
{
    public int osm_id;  
    public string amenity ;
    public string highway ;
    public string tags ;
    public float wayX ;
    public float wayY ;
    public int tl__Controller_controller_id ;
    public int cmp_longersection_id ;
    public int tl_group_id ;
    public int tl_Group_controller_id ;
    public int group_value ;
    public int tl_plan_id ;
    public int tl_Plan_controller_id ;
    public int plan_value ;
    public int duration ;
    public int tl_step_group_id ;
    public int tl_step_id ;
    public int tl_Step_Group_group_id ;
    public int tl_Step_step_id ;
    public int tl_Step_controller_id ;
    public int step_value ;
    public int max_step_time ;
    public int traffic_light_id ;
    public int feu ;
    public int tys ;
    public string type ;
    public int tl_Traffic_controller_id ;
    public float coordinatesX ;
    public float coordinatesY ;
    public int signal_Orientation ;
    public int gis_crosswalks_id ;
    public int gis_crosswalks_intersection_id ;
    public float gis_crosswalk_coordinatesX ;
    public float gis_crosswalk_coordinatesY ;
    public int bim_crosswalks_id ;
    public int bim_crosswalks_intersection_id ;
    public string bim_crosswalks_material_id ;
    public int bim_intersection_id ;
    public string bim_intersection_description ;
    public int gis_espiras_id ;
    public int gis_espiras_intersection_id ;
    public float gis_espiras_coordinatesX ;
    public float gis_espiras_coordinatesY ;
    public int bim_espiras_id ;
    public int bim_espiras_intersection_id ;
    public string bim_espiras_material_id ;
    public string bim_espiras_tipologia ;
    public string created;

}

