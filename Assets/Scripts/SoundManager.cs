using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingeltonBase<SoundManager>
{
    public AudioSource sfxAudio, musicAudio;
    public AudioClip die, win, pickupCoin,no1,no2,no3,ahshit,bgmusic,dead;
    public void playSfx(AudioClip clip)
    {
        if (sfxAudio != null && clip!=null && !sfxAudio.isPlaying)
        {
            sfxAudio.PlayOneShot(clip);
        }
    }  
    public void PlayDelayed(float time,AudioClip clip)
    {
        StartCoroutine(playdelay(time,clip));
    }

    IEnumerator playdelay(float t,AudioClip clip)
    {
        yield return new WaitForSeconds(t);
        if (sfxAudio != null && clip != null)
        {
            sfxAudio.PlayOneShot(clip);
        }
    }
    public void playMusic(AudioClip clip)
    {
        if (musicAudio != null && clip!=null)
        {
            musicAudio.volume=0.3f;
            musicAudio.clip = clip;
            musicAudio.Play();
        }
    }
}
