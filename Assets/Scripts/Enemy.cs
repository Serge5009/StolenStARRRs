using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField]
    float health = 100.0f;
   
    public GameObject coinDrop;
    public GameObject healthDrop;

    public int itemWeight;
    
    void Start()
    {
        itemWeight = Random.Range(0, 11);
    }

    void Update()
    {
        // if AI health less then 0
        if(health <= 0)
        {
            Destroy(gameObject);    //  RIP F
            
            if(itemWeight <= 6) //if random value less or equal then 6 drop coin
            {
              Instantiate(coinDrop, transform.position, Quaternion.identity);
            }
            else if(itemWeight >= 8) //if random value higher or equal then 8 drop health pickup
            {
             Instantiate(healthDrop, transform.position, Quaternion.identity);
            }
           else if(itemWeight == 7) // if its 7 drop both
            {
             Instantiate(coinDrop, transform.position, Quaternion.identity);
             Instantiate(healthDrop, transform.position, Quaternion.identity);
                
            }

            Debug.Log(itemWeight);
        }


    }

    public void GetDamage(float hp)
    {
        health -= hp;   // Does it need any explanation? 
    }
}
