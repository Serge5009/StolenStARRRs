using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class HealthBox : MonoBehaviour
{
    float cooldownHeal = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("touched the box xd");
            
            if(Player.player.health <= 100)
            {
                StartCoroutine(Heal());
            }
           
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("leaved the box xd");
        }
    }

    IEnumerator Heal()
    {
        while(Player.player.health < 100)
        {
            Player.player.health += 1;
            yield return new WaitForSeconds(cooldownHeal);
        }

    }
}
