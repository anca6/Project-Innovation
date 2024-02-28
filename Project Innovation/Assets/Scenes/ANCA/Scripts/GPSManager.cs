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

    private LandmarkManager landmarkManager;

    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        landmarkManager = FindObjectOfType<LandmarkManager>();

        //landmarkManager.InitializeLandmarks();
        

        StartCoroutine(GPSLocation());
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
            //timeStamp.text = Input.location.lastData.timestamp.ToString();

            horizontalAccuracy.text = Input.location.lastData.horizontalAccuracy.ToString();

            landmarkManager.playerPos = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);

            landmarkManager.CheckProximity();
        }
        else
        {
            //service stopped
        }
    }

}
