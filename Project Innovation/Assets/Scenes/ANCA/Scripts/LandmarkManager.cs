using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static LandmarkManager;

public class LandmarkManager : MonoBehaviour
{
    public float landmarkRadius = 100f; //landmark radius in meters to detect proximity

    public Vector2 playerPos;

    [System.Serializable]
    public class Landmark
    {
        public string name;
        public Vector2 position;
        public GameObject landmarkObject;
    }   

    public List<Landmark> landmarks = new List<Landmark>();


    public void CheckProximity()
    {
        //kvp = key-value pair
        foreach (var kvp in landmarks)
        //foreach (var landmark in landmarks.Values)
        {
            //for the cube to turn green
            MeshRenderer meshRenderer = kvp.landmarkObject.GetComponent<MeshRenderer>();

            float distance = Vector2.Distance(playerPos, kvp.position);

            if (distance <= landmarkRadius)
            {
                //for the cue to turn green
                meshRenderer.material.color = Color.green;

                //kvp.landmarkObject.SetActive(false); //for the cube to disappear
            }
        }
    }
}
