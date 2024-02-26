using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System;
using System.Collections.Generic;

public class GPSManager : MonoBehaviour
{
    public Text GPSStatus;
    public Text latitude;
    public Text longitude;
    public Text altitude;
    public Text horizontalAccuracy;
    public Text timeStamp;

    public float landmarkRadius = 100f; //landmark radius in meters to detect proximity

    private Vector2 playerPos;

    [SerializeField]
    public GameObject cubeLandmark;

    [SerializeField]
    public GameObject map;

    [Serializable]
    public struct Landmark
    {
        public string name;
        public Vector2 position;
    }

    public Dictionary<string, Landmark> landmarks = new Dictionary<string, Landmark> ();

    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        InitializeLandmarks();
        

        StartCoroutine(GPSLocation());
    }

    private void InitializeLandmarks()
    {
        landmarks.Add("Landmark1", new Landmark { name = "Ariensplein", position = new Vector2(52.220136f, 6.886714f) });
    }

    IEnumerator GPSLocation()
    {
        //check if user granted app permission
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            GPSStatus.text = "Location permission not granted";
            yield break;
        }
       

        //check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        //start service before querying location
        Input.location.Start();

        //wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        //service didnt initialize in 20 sec
        if (maxWait < 1)
        {
            GPSStatus.text = "Time out";
            yield break;
        }

        //connection failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Unable to detect device location";
            yield break;

        }
        else
        {
            GPSStatus.text = "Running";
            InvokeRepeating("UpdateGPSData", 0.5f, 1f);
        }

    }

    private void UpdateGPSData()
    {
        if(Input.location.status == LocationServiceStatus.Running)
        {
            GPSStatus.text = "Running";
            latitude.text = Input.location.lastData.latitude.ToString();
            longitude.text = Input.location.lastData.longitude.ToString();
            altitude.text = Input.location.lastData.altitude.ToString();
            timeStamp.text = Input.location.lastData.timestamp.ToString();

            horizontalAccuracy.text = Input.location.lastData.horizontalAccuracy.ToString();

            playerPos = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);

            CheckProximity();
        }
        else
        {
            //service stopped
        }
    }

    private void CheckProximity()
    {
        //kvp = key-value pair
        foreach(KeyValuePair<string, Landmark> kvp in landmarks)
        {
            float distance = Vector2.Distance(playerPos, kvp.Value.position);
            if(distance <= landmarkRadius)
            {
                Debug.Log("player is near landmark: " + kvp.Value.name);

                Renderer cubeRenderer = cubeLandmark.GetComponent<Renderer>();

                //change cube to green
                cubeRenderer.material.color = Color.green;
            }
        }
    }

    public void EnableMap()
    {
        cubeLandmark.SetActive(true);
        
        map.SetActive(true);

    }

}
