using UnityEngine;
using UnityEngine.UI;

public class SpriteClick : MonoBehaviour
{
    public Button plantButton;

    private void Start()
    {
        plantButton.gameObject.SetActive(false); 
    }

    private void OnMouseDown()
    {
        plantButton.gameObject.SetActive(!plantButton.gameObject.activeSelf);
    }

}
