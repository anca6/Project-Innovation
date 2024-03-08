using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic; // Reference to the AudioSource component that plays the background music

    private bool isMuted = false; // Variable to keep track of mute state

    private void Start()
    {
        // Ensure that the background music is initially unmuted
        backgroundMusic.volume = 1f;
    }

    // Function to toggle background music on/off
    public void ToggleMusic()
    {
        isMuted = !isMuted; // Toggle mute state

        // If muted, set volume to 0; otherwise, set volume to 1
        backgroundMusic.volume = isMuted ? 0f : 1f;
    }
}
