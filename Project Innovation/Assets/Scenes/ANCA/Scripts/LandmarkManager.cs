using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LandmarkManager;

public class LandmarkManager : MonoBehaviour
{
    public float landmarkRadius = 100f; //landmark radius in meters to detect proximity

    public Vector2 playerPos;

    //public GameObject cubeLandmark;

    [System.Serializable]
    public class Landmark
    {
        public string name;
        public Vector2 position;
        public GameObject landmarkObject;
    }   

    //private ObjectModifier modifier;

   /* [SerializeField]
    private GameObjectDictionary landmarks = new GameObjectDictionary();*/

    public List<Landmark> landmarks = new List<Landmark>();

    private void Start()
    {
        //InitializeLandmarks();
    }

    /*public void InitializeLandmarks()
    {
        landmarks.Add("Landmark1", new Landmark { name = "Main Building", position = new Vector2(52.21872f, 6.88789f) });
        //landmarks.Add("Landmark2", new Landmark { name = "Aici", position = new Vector2(52.220199806690125f, 6.890546263450228f) });
    }*/

    public void CheckProximity()
    {
        //kvp = key-value pair
        foreach (var kvp in landmarks)
        //foreach (var landmark in landmarks.Values)
        {

            float distance = Vector2.Distance(playerPos, kvp.position);

            if (distance <= landmarkRadius)
            {
                //Debug.Log("player is near landmark: " + kvp.Value.name);

                //Renderer cubeRenderer = cubeLandmark.GetComponent<Renderer>();

                //change cube to green
                //cubeRenderer.material.color = Color.green;

                //kvp.Value.enabled = false;
                //modifier.ChangeLandmarkColor(kvp.Value.gameObject, Color.green);

                kvp.landmarkObject.SetActive(false);
            }
        }
    }
}
