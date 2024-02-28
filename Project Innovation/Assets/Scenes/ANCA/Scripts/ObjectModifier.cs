using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectModifier : MonoBehaviour
{
    public void ChangeLandmarkColor(GameObject landmarkObj,  Color color)
    {
        MeshRenderer meshRenderer = landmarkObj.GetComponent<MeshRenderer>();

        if(meshRenderer != null)
        {
            Material material = new Material(Shader.Find("Standard"));
            material.color = color;
            meshRenderer.material = material;
        }
    }
}
