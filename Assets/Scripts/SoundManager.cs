using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource btnSound;
    public AudioSource btnSound1;

    public void SetBGMVolume(float volume)
    {
        BGM.volume=volume;
    }
    public void SetBtnVolume(float volume)
    {
        btnSound1.volume = volume;
        btnSound.volume = volume;
    }    

    public void OnSfx()
    {
        btnSound1.Play();
    }
}
