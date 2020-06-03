using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.InteropServices;
using System;

public class GetWeatherData : MonoBehaviour
{
    //USED TO ALLOW UNITY WEBGL TO INTERACT WITH JAVASCRIPT FILE IN JSLIB FILE
    //THE FUNCTION SPEAK IS DEFINED IN THE JSLIB FILE LOCATED IN ASSETS/PLUGINS
    [DllImport("__Internal")]
    private static extern void Speak(string str);

    string jsonString;

    Rootobject rootObject;


    //Root object class for json data
    [Serializable]
    public class Rootobject
    {
        public Coord coord;
        public Weather[] weather;
        public string _base;
        public Main main;
        public int visibility;
        public Wind wind;
        public Clouds clouds;
        public int dt;
        public Sys sys;
        public int timezone;
        public int id;
        public string name;
        public int cod;

        //parse json using JsonUtility
        public static Rootobject CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<Rootobject>(jsonString);
        }
    }

    [Serializable]
    public class Coord
    {
        public float lon;
        public float lat;
    }

    [Serializable]
    public class Main
    {
        public float temp;
        public float feels_like;
        public float temp_min;
        public int temp_max;
        public int pressure;
        public int humidity;

    }

    [Serializable]
    public class Wind
    {
        public int speed;
        public int deg;
    }

    [Serializable]
    public class Clouds
    {
        public int all;
    }

    [Serializable]
    public class Sys
    {
        public int type;
        public int id;
        public string country;
        public int sunrise;
        public int sunset;
    }

    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;

       
    }



    // Start is called before the first frame update
    void Start()
    {
        //A COROUTINE IS A FUNCTION THAT CAN SUSPEND ITS EXECUTION (yield) until the given YieldInstruction finishes
        //StartCoroutine - STARTS A COROUTINE
        StartCoroutine(loadData());
    }

    //Enumerator allows to stop the process at a specific moment, 
    //return that part of object (or nothing) and gets back to that point whenever you need it.
    IEnumerator loadData()
    {
        //create a webrequest object that will get the data from the api
        UnityWebRequest www = UnityWebRequest.Get("http://api.openweathermap.org/data/2.5/weather?q=galway&appid=a171c28cf9958f3ca164d974312f0e31&units=metric");

        //yield is the point at which execution will pause and be resumed the following frame
        yield return www.SendWebRequest();



        //get the string value of the json returned from the api
        jsonString = www.downloadHandler.text;

        rootObject = Rootobject.CreateFromJSON(jsonString);


    }


    public void talk()
    {
        //cuurent temperature from api
        float currentTemp = rootObject.main.temp;
               
        Speak("The current temperature is " + currentTemp.ToString() + "degrees");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
