using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float speed = 1.0f;
    float stopDistance = 2.0f;
    const float Chase_Range = 3.0f;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Chase();
       
        RangedAttack();
    }


    //just a basic chase function
    void Chase()
    {
            if (Vector2.Distance(transform.position, target.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //actual chase happening here .d

            }
            
    }
   
    void RangedAttack()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        float longAttRange = 7.0f;
        if(distance >= longAttRange)
        {
            // needs to implement stop chasing
            LongAttack();
        }
    }

    void LongAttack()
    {
        Debug.Log("imma attackiiiiing but from distance >.<");
    }

   

}
