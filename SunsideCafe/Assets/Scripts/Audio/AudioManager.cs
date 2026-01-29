using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private Settings settings;
    [SerializeField] private Sound[] musicSound;
    [SerializeField] private Sound[] sfxSound;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject)
;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        settings.LoadSettings();
        musicSource.volume = settings.musicVolume;
        sfxSource.volume = settings.sfxVolume;
    }
    public void PlayMusic(string name)
    {

        Sound s = Array.Find(musicSound, x => x.soundName == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }


    }

    public void PlaySFX(string name)
    {

        Sound s = Array.Find(sfxSound, x => x.soundName == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }

    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        settings.musicVolume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        settings.sfxVolume = volume;
    }

    public float GetMusicVolume()
    {
        return settings.musicVolume;
    }
    public float GetSFXVolume()
    {
        return settings.sfxVolume;
    }

    public void ApplyVolumeSettings()
    {
        SaveSystem.SaveSettings(settings);
    }

}