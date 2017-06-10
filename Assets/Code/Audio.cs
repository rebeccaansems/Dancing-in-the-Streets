using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static float musicVolume, sfxVolume;
    
    public AudioClip[] successAudioClips, negativeAudioClips;
    public AudioClip buttonClick;

    AudioSource aud;
    int prevAudS = 0, prevAudF = 0;

    public void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlaySuccessAudio()
    {
        int currAud = Random.Range(0, successAudioClips.Length);
        if (prevAudS != currAud)
        {
            aud.clip = successAudioClips[currAud];
        }
        else
        {
            currAud = Random.Range(0, successAudioClips.Length);
            aud.clip = successAudioClips[currAud];
        }
        prevAudS = currAud;
        aud.Play();
    }

    public void PlayNegativeAudio()
    {
        int currAud = Random.Range(0, negativeAudioClips.Length);
        if (prevAudS != currAud)
        {
            aud.clip = negativeAudioClips[currAud];
        }
        else
        {
            currAud = Random.Range(0, negativeAudioClips.Length);
            aud.clip = negativeAudioClips[currAud];
        }
        prevAudF = currAud;
        aud.Play();
    }

    public void PlayButtonClick()
    {
        aud.clip = buttonClick;
        aud.Play();
    }
}
