using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
    AudioObject : MonoBehaviour
{

    private AudioSource _audioSource;

    [SerializeField] private TypeAudio _type;
    public enum TypeAudio
    {
        Music,
        Sound
    }
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Debug.Log(_type);
        _audioSource.volume = _type switch
        {
            TypeAudio.Music => PlayerPrefs.GetInt(PlayerPrefsVariables.GetByEnum(PlayerPrefsVariables.List.Music), 
                1),
            TypeAudio.Sound => PlayerPrefs.GetInt(PlayerPrefsVariables.GetByEnum(PlayerPrefsVariables.List.Sound),
                1),
            _ => throw new ArgumentOutOfRangeException()
        };
        Debug.Log(_audioSource.volume);
    }

    public void SetType(TypeAudio type)
    {
        _type = type;
    }
}