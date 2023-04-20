using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    private AudioManager()
    {}

    public static AudioManager getInstance()
    {
        if (instance == null) instance = new AudioManager();
        return instance;
    }
    
    public void PlayAudio(AudioClip audio)
    {
        if(!audio) return;
        var prefab = new GameObject();
        var audioSource = prefab.AddComponent<AudioSource>();
        var d = prefab.AddComponent<AudioObject>();
        d.SetType(AudioObject.TypeAudio.Sound);
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void Vibrate(long time)
    {
        if(PlayerPrefs.GetInt(PlayerPrefsVariables.GetByEnum(PlayerPrefsVariables.List.Vibration), 1) == 1)
            Vibration.Vibrate(time);
    }

}