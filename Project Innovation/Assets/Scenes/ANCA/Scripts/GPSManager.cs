using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSManager : MonoBehaviour
{
    public Text GPSStatus;
    public Text latitude;
    public Text longitute;
    public Text altitude;
    public Text horizontalAccuracy;
    public Text timeStamp;

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
            //access granted
        }

    }

    private void UpdateGPSData()
    {
        if(Input.location.status == LocationServiceStatus.Running)
        {
            //access granted to gps values and has been initialized
        }
        else
        {
            //service stopped
        }
    }

}
