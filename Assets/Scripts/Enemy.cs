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
        if(health <= 0)
        {
            Destroy(gameObject);    //  RIP F
            
            if(itemWeight <= 6)
            {
              Instantiate(coinDrop, transform.position, Quaternion.identity);
            }
            else if(itemWeight >= 8)
            {
             Instantiate(healthDrop, transform.position, Quaternion.identity);
            }
           else if(itemWeight == 7)
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
