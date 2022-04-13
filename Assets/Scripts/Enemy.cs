using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float basicHealth = 100.0f;
    public float health;
   
    public GameObject coinDrop;
    public GameObject healthDrop;

    public int itemWeight;
    
    protected void Start()
    {
        itemWeight = Random.Range(0, 11);
        health = basicHealth;
    }

    protected void Update()
    {
        // if AI health less then 0
        if(health <= 0)
        {
            Die();
        }


    }

    protected virtual void Die()
    {
        //Telling level manager that it's one enemy less
        LevelManager.lManager.OnEnemyDeath();

        //Debug.Log("Dead!");

        SpawnDrop();

        Destroy(gameObject);    //  RIP F        
    }

    protected void SpawnDrop()    /////!!!!!!!!       THIS LOVELY CODE REQUIRES A COMPLETE REFACTOR                   !!!!!!! //////////                          PLEASE!
    {
        if (itemWeight <= 6) //if random value less or equal then 6 drop coin
        {
            Instantiate(coinDrop, transform.position, Quaternion.identity);
        }
        else if (itemWeight >= 8) //if random value higher or equal then 8 drop health pickup
        {
            Instantiate(healthDrop, transform.position, Quaternion.identity);
        }
        else if (itemWeight == 7) // if its 7 drop both
        {
            Instantiate(coinDrop, transform.position, Quaternion.identity);
            Instantiate(healthDrop, transform.position, Quaternion.identity);
        }
        //Debug.Log(itemWeight);
    }

    public virtual void GetDamage(float hp)
    {
        health -= hp;   // Does it need any explanation? 
        //Debug.Log("Enemy Health is: " + health);
    }
}
