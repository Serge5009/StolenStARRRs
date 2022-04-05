using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSave : MonoBehaviour
{
    public Text playerMoney;

    public void SaveGame()
    {
        PlayerPrefs.SetString("playerMoney", playerMoney.text);
        Debug.Log("Saved playerMoney: " + PlayerPrefs.GetString("playerMoney"));
    }
}
