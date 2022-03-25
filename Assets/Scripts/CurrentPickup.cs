using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickup : MonoBehaviour
{
    // if we have something more to pick up, here is the enum ^-^
    public enum PickupObject { COIN, HP, };
    public PickupObject currentObject;
    public int quantity;
    public AudioClip CoinPickup;
    //public AudioClip HealthPickupSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            // continue with else if when we have more to pick up 
            if(currentObject == PickupObject.COIN)
            {
                Player.player.coins += quantity;
                Debug.Log(Player.player.coins);
                AudioManager.Instance.Play(CoinPickup);
            }

            if (currentObject == PickupObject.HP && Player.player.health <= 100)
            {
                Player.player.health += quantity;
                Debug.Log(Player.player.health);
                //AudioManager.Instance.Play(HealthPickupSound);
            }

            Destroy(gameObject);
        }
    }
}
