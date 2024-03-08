using System.Collections;
using UnityEngine;
using UnityEngine.Android;

public class GPSManager : MonoBehaviour
{
    private LandmarkManager landmarkManager;

    private void Start()
    {
        //check if user granted app permission
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        landmarkManager = FindObjectOfType<LandmarkManager>();

        StartCoroutine(GPSLocation());
    }

    IEnumerator GPSLocation()
    {
        //check if user granted app permission
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
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
            yield break;
        }

        //connection failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;

        }
        else
        {
            InvokeRepeating("UpdateGPSData", 0.5f, 1f);
        }

    }

    private void UpdateGPSData()
    {
        if(Input.location.status == LocationServiceStatus.Running)
        {
            landmarkManager.playerPos = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);

            landmarkManager.CheckProximity();
        }
        else
        {
            //service stopped
        }
    }

}
