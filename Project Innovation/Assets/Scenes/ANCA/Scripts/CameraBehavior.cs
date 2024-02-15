using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CameraBehavior : MonoBehaviour
{
    public GameObject arCameraGameObj;
    public Camera arCameraComponent;

    public GameObject canvasGameObj;

    //public Camera canvasCamera;

    private void Start()
    {
        arCameraComponent.enabled = false;

        canvasGameObj.SetActive(true);
}
    public void ToggleCamera()
    {
        arCameraComponent.enabled = !arCameraComponent.enabled;

        canvasGameObj.SetActive(!arCameraComponent.enabled);
       // canvasCamera.gameObject.SetActive(arCameraComponent.enabled);
    }
}
