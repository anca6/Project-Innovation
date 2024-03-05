using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private bool backgroundMusicMuted = false;
    private bool soundEffectsMuted = false;

    public void ToggleBackgroundMusicMute()
    {
        backgroundMusicMuted = !backgroundMusicMuted;
        UpdateBackgroundMusicVolume();
    }

    public void ToggleSoundEffectsMute()
    {
        soundEffectsMuted = !soundEffectsMuted;
        UpdateSoundEffectsVolume();
    }

    private void UpdateBackgroundMusicVolume()
    {
        float volume = backgroundMusicMuted ? 0 : 1;
        // Replace "backgroundMusicSource" with your actual AudioSource variable for background music
        // Example: backgroundMusicSource.volume = volume;
    }

    private void UpdateSoundEffectsVolume()
    {
        float volume = soundEffectsMuted ? 0 : 1;
        // Replace "soundEffectsSource" with your actual AudioSource variable for sound effects
        // Example: soundEffectsSource.volume = volume;
    }
}
