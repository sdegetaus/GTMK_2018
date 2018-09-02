using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private AudioSource musicSource;
    private AudioSource soundFXSource;

    public SoundClass[] sounds;
    

    private bool clipHasPlayed;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
            if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        // we will manage the music preference with player prefs
        //right now it is inicialized in the lever manager at the save data region.
        foreach (SoundClass s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.priority = s.priority;
        }

        musicSource = Array.Find(sounds, sound => sound.name == "MainTheme").source; //Estaría bueno implementar enums
        musicSource.Play();
        clipHasPlayed = true;
    }

    public void Play(string name)
    {
        soundFXSource = Array.Find(sounds, sound => sound.name == name).source;
        if (soundFXSource == null)
        {
            return;
        }
        else
        {
            
            soundFXSource.Play();
        }

    }
}
