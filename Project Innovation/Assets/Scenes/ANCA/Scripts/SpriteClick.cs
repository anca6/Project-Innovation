using UnityEngine;
using UnityEngine.UI;

public class SpriteClick : MonoBehaviour
{
    public Button plantButton; //plant button to add flower to growth panel

    private void Start()
    {
        plantButton.gameObject.SetActive(false); 
    }

    private void OnMouseDown()
    {
        plantButton.gameObject.SetActive(!plantButton.gameObject.activeSelf);
    }

}
