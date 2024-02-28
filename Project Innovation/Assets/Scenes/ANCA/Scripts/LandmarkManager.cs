using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkManager : MonoBehaviour
{
    public float landmarkRadius = 100f; //landmark radius in meters to detect proximity

    public Vector2 playerPos;

    [SerializeField]
    private ObjectModifier modifier;

    [Serializable]
    public struct Landmark
    {
        public string name;
        public Vector2 position;

        public GameObject gameObject;

        public Landmark(string landmarkName, Vector2 landmarkPosition, GameObject obj)
        {
            name = landmarkName;
            position = landmarkPosition;    
            gameObject = obj;   
        }
    }

    public Dictionary<string, Landmark> landmarks = new Dictionary<string, Landmark>();


    public void InitializeLandmarks()
    {
        landmarks.Add("Landmark1", new Landmark { name = "Main Building", position = new Vector2(52.220136f, 6.886714f) });
    }

    public void CheckProximity()
    {
        //kvp = key-value pair
        /*foreach (KeyValuePair<string, Landmark> kvp in landmarks)*/
        foreach (var landmark in landmarks.Values)
        {
            float distance = Vector2.Distance(playerPos, landmark.position);

            if (distance <= landmarkRadius)
            {
                Debug.Log("player is near landmark: " + landmark.name);

                modifier.ChangeLandmarkColor(landmark, Color.green);

                //Renderer cubeRenderer = landmarks.GetComponent<Renderer>();

                //change cube to green
                //cubeRenderer.material.color = Color.green;
            }
        }
    }

    /*public void EnableMap()
    {
        cubeLandmark.SetActive(true);

        map.SetActive(true);

    }*/
}
