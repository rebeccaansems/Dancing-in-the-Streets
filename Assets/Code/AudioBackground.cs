using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    public AudioClip backgroundAudio;

    private AudioSource aud;
    private float currVolume;

    void Start()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        if(music.Length > 1)
        {
            Destroy(music[1]);
        }

        DontDestroyOnLoad(transform.gameObject);
        aud = GetComponent<AudioSource>();
        if (!aud.isPlaying)
        {
            aud.playOnAwake = true;
            aud.loop = true;
            aud.clip = backgroundAudio;
            aud.volume = Audio.musicVolume;
            aud.Play();
            currVolume = Audio.musicVolume;
        }
    }

    public void Update()
    {
        if (currVolume != Audio.musicVolume)
        {
            aud.volume = Audio.musicVolume;
            currVolume = Audio.musicVolume;
        }
    }
}
