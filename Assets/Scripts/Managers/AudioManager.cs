using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   static private AudioManager _Instance;
    const int NUM_AUDIOSOURCES = 7;
    AudioSource[] Source = new AudioSource[NUM_AUDIOSOURCES];
    int currentAudioSourceID = 0;
   static public AudioManager Instance
    {
        get 
        {
            if ( _Instance == null)
            {
                _Instance = GameObject.FindObjectOfType<AudioManager>();
                if (_Instance == null)
                {
                    GameObject Manager = new GameObject("AudioManger");
                    _Instance = Manager.AddComponent<AudioManager>();

                    for (int i = 0; i < NUM_AUDIOSOURCES; i++)
                    {
                        _Instance.Source[i] = Manager.AddComponent<AudioSource>();
                    }
                }
            }
            return _Instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Play(AudioClip Sound)
    {
        Source[currentAudioSourceID].clip = Sound;
        Source[currentAudioSourceID].Play();
        currentAudioSourceID++;
        if (currentAudioSourceID >= NUM_AUDIOSOURCES)
        {
            currentAudioSourceID = 0;
        }
    }
}
