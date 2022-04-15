using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    
    float stopDistance = 2.0f;
    const float Chase_Range = 3.0f;
    [SerializeField]
    float agroRange;

    [SerializeField]
    float speed;


    private Transform target;
    private float distanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position); //getting the distance between boss and player
        Debug.Log("Distance: " + distanceToPlayer);

        if(distanceToPlayer < agroRange)
        {
            Chase();
        }
        else
        {
           
        }
    }


    //just a basic chase function
    void Chase()
    {     
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //actual chase happening here .d   
    }
   
    void StopChase()
    { 

    }

 
   

}
