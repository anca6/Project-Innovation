using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LandmarkManager : MonoBehaviour, IPointerClickHandler
{
    public float landmarkRadius = 100f; //landmark radius in meters to detect proximity

    public Vector2 playerPos;

    //bool canClick = false;
    [System.Serializable]
    public class Landmark
    {
        public string name;
        public Vector2 position;
        public GameObject landmarkObject;
    } 

    public List<Landmark> landmarks = new List<Landmark>();

    public void OnPointerClick(PointerEventData eventData)
    {
        // This method will be called when the quad is clicked
        Debug.Log("Quad clicked!");
    }

    public void CheckProximity()
    {
        //kvp = key-value pair
        foreach (Landmark kvp in landmarks)
        //foreach (var landmark in landmarks.Values)
        {
            //for the cube to turn green
            //MeshRenderer meshRenderer = kvp.landmarkObject.GetComponent<MeshRenderer>();

            //canClick = true;

            float distance = Vector2.Distance(playerPos, kvp.position);

            if (distance <= landmarkRadius)
            {
                //for the cue to turn green
                //meshRenderer.material.color = Color.green;

                //kvp.landmarkObject.SetActive(false); //for the cube to disappear

                //canClick = true;
            }
            //canClick = false;
        }
        
    }

    /*public void ShowPlantUI()
    {
        foreach(Landmark kvp in landmarks)
        {
            if(canClick == true)
            {

            }
        }
    }*/
}
