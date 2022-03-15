using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : Projectile
{
    Projectile projScript;

    [SerializeField]
    float safeTime = 0.4f;
    bool isTriggerActive = false;

    [SerializeField]
    float explosionTriggerRad = 1.5f;   //  Radius of enemy scan
    [SerializeField]
    float explosionTriggerDelay = 1.0f; //  Once per X seconds will check for enemies in radius

    GameObject[] enemies;


    void Start()
    {
        projScript = GetComponent<Projectile>();
        if (!projScript)
            Debug.Log("Error connecting script");

    }

    float timer = 0.0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= safeTime && !isTriggerActive)  //  Handles time before 
        {
            isTriggerActive = true;
            timer = 0.0f;
            projScript.isExplosive = true;
        }

        if (timer >= explosionTriggerDelay && isTriggerActive)  //  Called every X seconds
        {
            timer -= explosionTriggerDelay;
            //Debug.Log("Scan");
            UpdateEnemies();                //  Looks if there any enemies in radius
        }
    }

    void UpdateEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");   //  Save all existing enemies to one list
        //Debug.Log(enemies.Length);

        foreach (GameObject AI in enemies)          //  Loop thru all enemies
        {
            float distane = Vector3.Distance(AI.transform.position, transform.position);    //  Find distance from bullet to enemy
            //Debug.Log(distane);

            if(distane < explosionTriggerRad)               //  If close enough
            {
                Explode();                                  //  Bullet go boooom
            }
        }
    }

    void Explode()
    {
        Debug.Log("Boom?");
    }
}
