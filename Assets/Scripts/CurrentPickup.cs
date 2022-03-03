using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPickup : MonoBehaviour
{
    // if we have something more to pick up, here is the enum ^-^
    public enum PickupObject { COIN, HP, };
    public PickupObject currentObject;
    public int quantity;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            // continue with else if when we have more to pick up 
            if(currentObject == PickupObject.COIN)
            {
                Player.player.coins += quantity;
                Debug.Log(Player.player.coins);
            }

            if (currentObject == PickupObject.HP)
            {
                Player.player.health += quantity;
                Debug.Log(Player.player.health);
            }

            Destroy(gameObject);
        }
    }
}
