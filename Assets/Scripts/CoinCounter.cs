using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinCounter : MonoBehaviour
{
    Text text;

    void Start()
    {

        text = GetComponent<Text>(); 
    }
    void Update()
    {
        
        text.text = Player.player.coins.ToString();   
    }
}
