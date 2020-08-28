using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class AudioManager : MonoBehaviour
{

    public AudioMixerGroup musicMixerGroup;
    public AudioMixer musicMixer;

    public AudioMixerGroup SFXMixerGroup;
    public AudioMixer SFXMixer;
    public Sound[] sounds;

    // reference to the AudioManager of our scene
    public static AudioManager instance;
    void Awake()
    {
        // If there isn't already an audio manager in the scene, assign it to this
        if (instance == null)
            instance = this;
        // else, destroy extra audio manager 
        else
        {
            Destroy(gameObject);
            return;
        }

        //Determine if the gameobject is childed, then unchild it
        if (gameObject.transform.parent != null)
        {
            gameObject.transform.parent = null;
        }

        // Prevents music from restarting during every new level
        DontDestroyOnLoad(gameObject);
        // Add AudioSources to each sound in the sounds array
        foreach (Sound s in sounds)
        {
            // Create an audiosource for each of the Sound objects
            s.source = gameObject.AddComponent<AudioSource>();

            // Assign the properties of the audiosources to the properties of the Sound object
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
            // Adjust the volume depending on the kind of sound
            if (s.name == "Hop" || s.name == "Mud")
            {
                s.source.volume = 1f; 
            }
            else if (s.name == "Electrical Current")
            {
                s.source.volume = 0.2f; 
            }
            else if (s.name == "GameplayMusic")
            {
                s.source.volume = 0.5f;
            } 
            else if (s.name == "ButtonOn" || s.name == "Buttonoff")
            {
                s.source.volume = 0.75f; 
                s.source.pitch = 0.8f; 
            }
            else if (s.name == "Star1" || s.name == "Star2" || s.name == "Star3" || s.name == "DiamondStars")
            {
                s.source.pitch = 0.7f; 
            }
            else 
            {
                s.source.volume = 0.75f; 
            }
            s.volume = s.source.volume; 

            // sets the outputs of the audio sources to the correct audio mixer groups
            if (s.name == "GameplayMusic")
                s.source.outputAudioMixerGroup = musicMixerGroup;
            else
                s.source.outputAudioMixerGroup = SFXMixerGroup;

        }
    }

    void Start()
    {
        //Sets the music and sfx volumes to whatever is saved in the player prefs
        musicMixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Music Volume", 0.2f)) * 20);
        SFXMixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("SFX Volume", 1.0f)) * 20);

        SetLoop(true, "GameplayMusic");
        Play("GameplayMusic"); 
    }

    // finds sound of specified name
    public Sound FindSound(string name)
    {
        // find sound in sounds array where sound.name equals the specified name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // return if you can't find the name of the sound
        if (s == null)
        {
            //Debug.LogWarning("Sound: " + name + " not found!");
            return null;
        }
        else if (s.source == null)
        {
            //Debug.LogWarning("Sound: " + name + " source not found!"); 
            return null; 
        }
        return s;
    }

    // plays sound with specified name
    public void Play(string name)
    {
        Sound s = FindSound(name);
        if (s != null)
        {
            s.source.Play();
        }
    }

    // sets the pitch of a sound of a specified name
    public void SetPitch(float pitch, string name)
    {
        Sound s = FindSound(name);
        if (s != null)
        {
            s.source.pitch = pitch;
        }
    }

    // disables or enables the looping of a specified sound
    public void SetLoop(bool loop, string name)
    {
        Sound s = FindSound(name);
        if (s != null)
        {
            s.source.loop = loop;
        }
    }
}
