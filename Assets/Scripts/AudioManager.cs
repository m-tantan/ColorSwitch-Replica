using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    public static AudioManager audioManager;
    
    public Sound[] sounds;

	void Awake () {
        if (audioManager == null)
            audioManager = this;
        else {
            Destroy(gameObject);
            return; 
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isLoop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = s.isPlayOnAwake;
        }

	
    }

    
    void Start() {
        playSound("BackgroundMusic");
        
    }

    public void playSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Missing sound: " + name);
            return;
        }

        s.source.Play();
    }


    public void editMusicVolume(float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == "BackgroundMusic");
        if (s == null)
        {
            Debug.LogWarning("Missing sound: " + name);
            return;
        }
        s.source.volume = volume;
    }

    public void editSoundsVolume(float volume)
    {
        foreach(Sound s in sounds) {
            if (s==null)
            {
                Debug.LogWarning("Missing sound! " + s.name);
            }
            if(s.name == "BackgroundMusic")
            {
                continue;
            }
            s.source.volume = volume;
        }

        
    }
	
	
}
