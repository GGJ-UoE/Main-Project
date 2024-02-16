using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingeltonBase<SoundManager>
{
    public AudioSource sfxAudio1, sfxAudio2, sfxAudio3, musicAudio;
    public AudioClip die, win, pickupCoin,no1,no2,no3,ahshit,bgmusic,dead,Goat,Coin_collect,Coin_Run;
    public void playSfx(AudioClip clip,float pitch,float volume)
    {
        if (sfxAudio1 != null && clip!=null && !sfxAudio1.isPlaying)
        {
            sfxAudio1.pitch = pitch;
            sfxAudio1.volume = volume;
            sfxAudio1.PlayOneShot(clip);
            return;
        }
        else if (sfxAudio2 != null && clip != null && !sfxAudio2.isPlaying)
        {
            sfxAudio2.pitch = pitch;
            sfxAudio2.volume = volume;
            sfxAudio2.PlayOneShot(clip);
            return;
        }
        else if (sfxAudio3 != null && clip != null && !sfxAudio3.isPlaying)
        {
            sfxAudio3.pitch = pitch;
            sfxAudio3.volume = volume;
            sfxAudio3.PlayOneShot(clip);
            return;
        }
    }  
    public void PlayDelayed(float time,AudioClip clip,float pitch, float volume)
    {
        StartCoroutine(playdelay(time,clip,pitch,volume));
    }

    IEnumerator playdelay(float t,AudioClip clip,float pitch,float volume)
    {
        yield return new WaitForSeconds(t);
        playSfx(clip, pitch, volume);
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
