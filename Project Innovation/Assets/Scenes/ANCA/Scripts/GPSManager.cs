using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSManager : MonoBehaviour
{
    public Text GPSStatus;
    public Text latitude;
    public Text longitude;
    public Text altitude;
    public Text horizontalAccuracy;
    public Text timeStamp;

    private void Start()
    {
        StartCoroutine(GPSLocation());
    }

    IEnumerator GPSLocation()
    {
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
        }
        else
        {
            //service stopped
        }
    }

}
