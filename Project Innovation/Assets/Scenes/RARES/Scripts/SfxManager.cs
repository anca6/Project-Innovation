using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource sfx;
    
    public void playButton()
    {
        sfx.Play();
    }
}
