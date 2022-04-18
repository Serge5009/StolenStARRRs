using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    float stopDistance = 2.0f;
    const float Chase_Range = 3.0f;
    [SerializeField]
    float agroRange;

    [SerializeField]
    float speed;

    [SerializeField]
    float wanderRange;

    [SerializeField]
    float maxDistance;

    /*
    [SerializeField]
    GameObject player;
    */
    Vector2 wayPoint;

   // Vector2 dodge;

    private Transform target;
    private float distanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
        SetPath();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position); //getting the distance between boss and player
        Debug.Log("Distance: " + distanceToPlayer);

        if (distanceToPlayer < agroRange)
        {
            Chase();
            //GetAway();
        }
        else
        {
            Wander();
        }
    }


    //just a basic chase function
    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //actual chase happening here .d   

    }

    void Wander()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime); // wandering
        if(Vector2.Distance(transform.position, wayPoint) < wanderRange)
        {
            SetPath(); //setting new path here

        }
    }

    void SetPath()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance)); //random path creation

    }

    /*
    void GetAway()
    {
        
    }
    */
}