using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectModifier : MonoBehaviour
{
    public void ChangeLandmarkColor(LandmarkManager.Landmark landmark,  Color color)
    {
        MeshRenderer meshRenderer = landmark.gameObject.GetComponent<MeshRenderer>();

        if(meshRenderer != null)
        {
            Material material = new Material(Shader.Find("Standard"));
            material.color = color;
            meshRenderer.material = material;
        }
    }
}
