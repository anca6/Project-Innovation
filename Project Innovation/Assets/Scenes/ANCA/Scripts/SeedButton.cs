using UnityEngine;

public class SeedButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        GameManager.instance.SetButtonClicked(true);


    }
}
