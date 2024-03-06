using UnityEngine;

public class PopupCard : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToDisable;

    //private bool isEnabled = false;

    public void ToggleObject()
    {
        // If object is enabled, disable it. If disabled, enable it.
        objectToDisable.SetActive(!objectToDisable.activeSelf);
        //isEnabled = objectToDisable.activeSelf;
        gameObject.SetActive(true);
    }
}
