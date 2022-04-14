using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsSave : MonoBehaviour
{
    public Slider volume1;
    public Slider volume2;
    public TMP_Dropdown quality;
    public TMP_Dropdown resolution;
    public Toggle fullscreen;

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("volume1", volume1.value);
        Debug.Log("Saved volume: " + PlayerPrefs.GetFloat("volume1"));

        PlayerPrefs.SetFloat("volume2", volume2.value);
        Debug.Log("Saved volume: " + PlayerPrefs.GetFloat("volume2"));

        PlayerPrefs.SetInt("quality", quality.value);
        Debug.Log("Saved quality: " + PlayerPrefs.GetInt("quality"));

        PlayerPrefs.SetInt("resolution", resolution.value);
        Debug.Log("Saved resolution: " + PlayerPrefs.GetInt("resolution"));

        bool fsBool = fullscreen.isOn;
        int fsInt = 0;
        if (fsBool)
        {
            fsInt = 1;
        }
        else
        {
            fsInt = 0;
        }
        PlayerPrefs.SetInt("fullscreen", fsInt);
        Debug.Log("Saved fullscreen toggle: " + PlayerPrefs.GetInt("fullscreen"));
    }
}
