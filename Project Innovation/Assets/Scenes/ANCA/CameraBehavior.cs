using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CameraBehavior : MonoBehaviour
{
    public GameObject arCamera;


    public void ToggleCamera()
    {
        arCamera.SetActive(!arCamera.activeSelf);
    }
}
