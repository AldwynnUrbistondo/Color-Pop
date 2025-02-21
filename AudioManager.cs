using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Audiosource;

    public void playAudio()
    {
        Audiosource.Play();
    }
}
