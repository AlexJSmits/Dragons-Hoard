using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider SFXSlider;
    public Slider musicSlider;

    const string MIXER_MASTER = "MasterVolume";
    const string MIXER_SFX = "SFXVolume";
    const string MIXER_MUSIC = "MusicVolume";

    void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    void SetMasterVolume(float value)
    {
        audioMixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }

    void SetSFXVolume(float value)
    {
        audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    void SetMusicVolume(float value)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
}
