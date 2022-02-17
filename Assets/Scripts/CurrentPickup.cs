using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickup : MonoBehaviour
{
    // if we have something more to pick up, here is the enum ^-^
    public enum PickupObject { COIN, };
    public PickupObject currentObject;
    public int quantity;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            // continue with else if whne we have more to pick up 
            if(currentObject == PickupObject.COIN)
            {
                Player.player.coins += quantity;
                Debug.Log(Player.player.coins);
            }
            Destroy(gameObject);
        }
    }
}
