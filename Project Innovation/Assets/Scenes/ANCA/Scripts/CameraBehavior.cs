using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Camera arCameraComponent;


    public Camera canvasCamera;

    private void Start()
    {
        arCameraComponent.enabled = false;

        canvasCamera.enabled = true;
}
    public void ToggleCamera()
    {
        arCameraComponent.enabled = !arCameraComponent.enabled;

        canvasCamera.gameObject.SetActive(false);
    }
}
