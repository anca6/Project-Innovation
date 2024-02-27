using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkManager : MonoBehaviour
{
    public float landmarkRadius = 100f; //landmark radius in meters to detect proximity

    public Vector2 playerPos;

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

    public Dictionary<string, Landmark> landmarks = new Dictionary<string, Landmark>();


    public void InitializeLandmarks()
    {
        landmarks.Add("Landmark1", new Landmark { name = "Main Building", position = new Vector2(52.220136f, 6.886714f) });
    }

    public void CheckProximity()
    {
        //kvp = key-value pair
        foreach (KeyValuePair<string, Landmark> kvp in landmarks)
        {
            float distance = Vector2.Distance(playerPos, kvp.Value.position);
            if (distance <= landmarkRadius)
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
