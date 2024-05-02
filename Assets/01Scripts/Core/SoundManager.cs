using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Sound
{
    public string name;
    public AudioClip clip;
}

enum AudioType
{
    SFX,
    BGM, 
    EnumCount
}

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private AudioSource[] _sources = new AudioSource[(int)AudioType.EnumCount];

    [SerializeField] private Sound[] _sfxList;
    [SerializeField] private Sound[] _bgmList;
    private Dictionary<string, AudioClip> _sfxDictionary = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> _bgmDictionary = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        foreach (Sound sound in _sfxList)
        {
            _sfxDictionary[sound.name] = sound.clip;
        }

        foreach (Sound sound in _bgmList)
        {
            _bgmDictionary[sound.name] = sound.clip;
        }
    }

    public void PlaySFX(string name)
    {
        if (_sfxDictionary.ContainsKey(name))
        {
            AudioClip clip = _sfxDictionary[name];
            _sources[(int)AudioType.SFX].clip = clip;
            _sources[(int)AudioType.SFX].Play();
        }
        else
        {
            Debug.LogError("그러한 소리는 없는데");
        }
    }

    public void PlayBGM(string name)
    {
        if (_bgmDictionary.ContainsKey(name))
        {
            AudioClip clip = _bgmDictionary[name];
            _sources[(int)AudioType.BGM].clip = clip;
            _sources[(int)AudioType.BGM].loop = true;
            _sources[(int)AudioType.BGM].Play();
        }
        else
        {
            Debug.LogError("그러한 소리는 없는데");
        }
    }
}
