using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    FLYMUSIC,
    HANGARMUSIC,
    DEATH,
    NEARMISS,
    PICKUP,
    BOOST,
    WARNING,
    DEATH2
}


[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance;
    [SerializeField] private AudioClip[] soundList;
    private Dictionary<SoundType, AudioSource> soundSources;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        soundSources = new Dictionary<SoundType, AudioSource>();

        for (int i = 0; i < soundList.Length; i++)
        {
            SoundType sound = (SoundType)i;

            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = soundList[i];

            soundSources[sound] = source;
        }
    }

    private void Start()
    {
        
    }

    public static void Play(SoundType sound, float volume = 1f, float pitch = 1f, bool loop = false)
    {
        if (instance.soundSources.TryGetValue(sound, out AudioSource source))
        {
            
            source.volume = volume;
            source.pitch = pitch;
            source.loop = loop;
            source.Play();
        }
    }

    public static void Stop(SoundType sound)
    {
        if (instance.soundSources.TryGetValue(sound, out AudioSource source))
        {
            source.Stop();
        }
    }
}
