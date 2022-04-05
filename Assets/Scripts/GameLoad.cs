using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLoad : MonoBehaviour
{
    public Text playerMoney;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney.text = PlayerPrefs.GetString("playerMoney");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
