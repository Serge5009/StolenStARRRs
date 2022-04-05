using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OptionsLoad : MonoBehaviour
{
    public Slider volume;
    public TMP_Dropdown quality;
    public TMP_Dropdown resolution;
    public Toggle fullscreen;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("resolution"))
        {
            resolution.value = PlayerPrefs.GetInt("resolution");
        }
        else
        {
            resolution.value = 20;
        }

        volume.value = PlayerPrefs.GetFloat("volume");
        quality.value = PlayerPrefs.GetInt("quality");

        if (PlayerPrefs.HasKey("fullscreen"))
        {
            if (PlayerPrefs.GetInt("fullscreen") == 1)
            {
                fullscreen.isOn = true;
            }
            else
            {
                fullscreen.isOn = false;
            }
            Debug.Log("Loaded quality: " + PlayerPrefs.GetFloat("quality"));
            Debug.Log("Loaded volume: " + PlayerPrefs.GetFloat("volume"));
            Debug.Log("Loaded resolution: " + PlayerPrefs.GetFloat("resolution"));
        }
        else
        {
            fullscreen.isOn = true;
            Debug.Log("Loaded fullscreen: " + PlayerPrefs.GetFloat("fullscreen"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
