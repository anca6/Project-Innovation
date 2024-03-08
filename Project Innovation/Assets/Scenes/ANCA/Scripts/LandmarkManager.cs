using System.Collections.Generic;
using UnityEngine;

public class LandmarkManager : MonoBehaviour
{
    public float landmarkRadius = 100f; //landmark radius in meters to detect proximity

    public Vector2 playerPos; //to store player position in X,Y coord

    [System.Serializable]
    public class Landmark
    {
        public string name;
        public Vector2 position;
        public GameObject landmarkObject;

    }
    public bool canClick = false;

    public List<Landmark> landmarks = new List<Landmark>();


    public void CheckProximity()
    {
        bool isInRadius = false;

        foreach (Landmark kvp in landmarks)
        {
            float distance = Vector2.Distance(playerPos, kvp.position);

            if (distance <= landmarkRadius)
            { 
                MeshRenderer meshRenderer = kvp.landmarkObject.GetComponent<MeshRenderer>();
                meshRenderer.material.color = Color.green;

                isInRadius = true;  
            }
        }
        canClick = isInRadius;

    }

}
