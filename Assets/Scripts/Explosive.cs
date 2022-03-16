using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    Projectile projScript;


        //  Explosion trigger settings
    [SerializeField]
    float safeTime = 0.4f;
    bool isTriggerActive = false;
    [SerializeField]
    float explosionTriggerRad = 1.5f;   //  Radius of enemy scan
    [SerializeField]
    float explosionTriggerDelay = 1.0f; //  Once per X seconds will check for enemies in radius

        //  Explision settings
    float damage;
    [SerializeField]
    float explosionRad = 2.0f;
    float distDmgFactor = 0.67f;

    GameObject[] enemies;


    void Start()
    {
        projScript = GetComponent<Projectile>();
        if (!projScript)
            Debug.Log("Error connecting script");
        damage = projScript.damage;
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
            float distance = Vector3.Distance(AI.transform.position, transform.position);    //  Find distance from bullet to enemy
            //Debug.Log(distane);

            if(distance < explosionTriggerRad)               //  If close enough
            {
                Debug.Log("Enemy in range");
                Explode();                                  //  Bullet go boooom
                return;     //We dont want multiple explosions 
            }
        }
    }

    public void Explode()
    {
        if (projScript.damageEnemy)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");   //  Save all existing enemies to one list

            foreach (GameObject AI in enemies)
            {
                float distance = Vector3.Distance(AI.transform.position, transform.position);    //  Find distance from bullet to enemy

                if (distance < explosionRad)
                {
                    Enemy target = AI.gameObject.GetComponent<Enemy>();    //  Getting the enemy object of our hit target
                    float dmg = damage * ((explosionRad - distance) / explosionRad);    //  Linear equation of damage from distance
                    target.GetDamage(dmg);
                    Debug.Log(dmg);

                    //  Knock AI from epicenter                         !!! NEEDS REWORK !!!
                    Vector3 direction = AI.transform.position - transform.position;
                    direction = Vector3.Normalize(direction);

                    Vector2 dirrr = direction;

                    Rigidbody2D rb = AI.gameObject.GetComponent<Rigidbody2D>();
                    rb.velocity += dirrr;
                    //rb.AddForce(direction * damage);
                }
            }
        }



        Destroy(gameObject);
    }
}
