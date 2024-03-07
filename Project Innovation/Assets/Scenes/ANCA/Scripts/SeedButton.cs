using UnityEngine;

public class SeedButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        GameManager.instance.SetButtonClicked(true);
        Debug.Log("added seed fr");

    }
}
