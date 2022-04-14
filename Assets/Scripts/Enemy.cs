using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float basicHealth = 100.0f;
    public float health;
   
    //public GameObject coinDrop;
    //public GameObject healthDrop;


    //  elenent 1 of weight is how likely is element 1 of dropPrefab to be spawned
    [SerializeField]
    float[] weight;
    [SerializeField]
    GameObject[] dropPrefab;

    //public int itemWeight;
    
    protected void Start()
    {
        //itemWeight = Random.Range(0, 11);
        health = basicHealth;

        if(weight.Length != dropPrefab.Length)
        {
            Debug.Log("Attantion!!! Weight and dropPrefab arrays MUST be the same lenght");
        }
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
        float weigtSum = 0;       //  Get a sum of all weight for drops
        foreach (float i in weight)
            weigtSum += i;

        float randInt = Random.Range(0, weigtSum);  //  Get a random value between 0 and weight sum

        bool isDropFound = false;
        int acriveDrop = 0;
        while (!isDropFound)    //  Loop thru all positions untill got a match
        {
            if(weight[acriveDrop] > randInt)    //  If random value is within this prefab's weight
            {
                isDropFound = true;
                Instantiate(dropPrefab[acriveDrop], transform.position, Quaternion.identity);   //  Spawn drop
            }
            else
            {
                randInt -= weight[acriveDrop];  //  Move to next option
                acriveDrop++;
            }
        }

        //if (itemWeight <= 6) //if random value less or equal then 6 drop coin
        //{
        //    Instantiate(coinDrop, transform.position, Quaternion.identity);
        //}
        //else if (itemWeight >= 8) //if random value higher or equal then 8 drop health pickup
        //{
        //    Instantiate(healthDrop, transform.position, Quaternion.identity);
        //}
        //else if (itemWeight == 7) // if its 7 drop both
        //{
        //    Instantiate(coinDrop, transform.position, Quaternion.identity);
        //    Instantiate(healthDrop, transform.position, Quaternion.identity);
        //}
        //Debug.Log(itemWeight);
    }

    public virtual void GetDamage(float hp)
    {
        health -= hp;   // Does it need any explanation? 
        //Debug.Log("Enemy Health is: " + health);
    }
}
