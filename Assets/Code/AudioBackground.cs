using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    public AudioClip backgroundAudio;

    private AudioSource aud;
    private float currVolume;

    void Awake()
    {
        aud = GetComponent<AudioSource>();
        currVolume = Audio.musicVolume;

        DontDestroyOnLoad(transform.gameObject);
        aud.playOnAwake = true;
        aud.loop = true;
        aud.clip = backgroundAudio;
        aud.Play();
    }

    public void Update()
    {
        if(currVolume != Audio.musicVolume)
        {
            aud.volume = Audio.musicVolume;
            currVolume = Audio.musicVolume;
        }
    }
}
