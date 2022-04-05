using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsSave : MonoBehaviour
{
    public Slider volume;
    public TMP_Dropdown quality;
    public TMP_Dropdown resolution;
    public Toggle fullscreen;

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("volume", volume.value);
        Debug.Log("Saved volume: " + PlayerPrefs.GetFloat("volume"));

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
