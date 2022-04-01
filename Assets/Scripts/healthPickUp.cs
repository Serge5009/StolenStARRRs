using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour
{
    // if we have something more to pick up, here is the enum ^-^
    public enum PickupObject {HP, };
    public PickupObject currentObject2;
    public int quantity2;
    
    public AudioClip HealthPickupSound;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            if (currentObject2 == PickupObject.HP && Player.player.health <= 100)
            {
                Player.player.health += quantity2;
                Debug.Log(Player.player.health);
                AudioManager.Instance.Play(HealthPickupSound);
            }

            Destroy(gameObject);
        }
    }
}
