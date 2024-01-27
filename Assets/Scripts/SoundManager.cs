using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingeltonBase<SoundManager>
{
    public AudioSource sfxAudio, musicAudio;
    public AudioClip die, win, pickupCoin;
    public void playSfx(AudioClip clip)
    {
        if (sfxAudio != null && clip!=null)
        {
            sfxAudio.PlayOneShot(clip);
        }
    }

    public void playMusic(AudioClip clip)
    {
        if (musicAudio != null && clip!=null)
        {
            musicAudio.clip = clip;
            musicAudio.Play();
        }
    }
}
