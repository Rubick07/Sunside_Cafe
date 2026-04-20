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
    [SerializeField] private Sound[] ambienceSound;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource ambienceSource;

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
        ambienceSource.volume = settings.musicVolume;
        sfxSource.volume = settings.sfxVolume;
    }

    [Yarn.Unity.YarnCommand("PlayMusic")]
    public void PlayMusic(string name)
    {
        musicSource.UnPause();

        Sound s = Array.Find(musicSound, x => x.soundName == name);

        if (musicSource.clip == s.clip)
            return;

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
    [Yarn.Unity.YarnCommand("StopMusic")]
    public void StopMusic()
    {
        musicSource.Stop();
        musicSource.clip = null;
    }

    [Yarn.Unity.YarnCommand("PlaySFX")]
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

    [Yarn.Unity.YarnCommand("StopSFX")]
    public void StopSFX()
    {
        sfxSource.Stop();
        sfxSource.clip = null;
    }

    [Yarn.Unity.YarnCommand("PlayAmbience")]
    public void PlayAmbience(string name)
    {

        Sound s = Array.Find(ambienceSound, x => x.soundName == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            ambienceSource.clip = s.clip;
            ambienceSource.Play();
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

        ambienceSource.volume = volume;
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

    private void OnEnable()
    {
        GameEvents.OnPlaySFX += PlaySFX;
        GameEvents.OnPlayMusic += PlayMusic;
        GameEvents.OnPlayAmbience += PlayAmbience;

    }

    private void OnDisable()
    {
        GameEvents.OnPlaySFX -= PlaySFX;
        GameEvents.OnPlayMusic -= PlayMusic;
        GameEvents.OnPlayAmbience -= PlayAmbience;
    }
}