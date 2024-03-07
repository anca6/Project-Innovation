using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public Sprite originalSprite; // The original sprite
    public Sprite alternateSprite; // The alternate sprite

    private Image imageComponent; // Reference to the Image component
    private bool isOriginal = true; // Flag to track the current sprite state

    void Start()
    {
        // Get the Image component attached to this GameObject
        imageComponent = GetComponent<Image>();
    }

    public void ToggleSprite()
    {
        // Toggle between original and alternate sprites
        if (isOriginal)
        {
            if (originalSprite != null)
            {
                imageComponent.sprite = originalSprite;
            }
        }
        else
        {
            if (alternateSprite != null)
            {
                imageComponent.sprite = alternateSprite;
            }
        }

        // Invert the flag for the next click
        isOriginal = !isOriginal;
    }
}