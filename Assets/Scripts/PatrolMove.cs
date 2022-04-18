using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMove : MonoBehaviour
{
    [SerializeField]
    float stopDistance = 2.0f;

    
    [SerializeField]
    float agroRange;

    [SerializeField]
    float speed;

    [SerializeField]
    float wanderRange;

    [SerializeField]
    float maxDistance;

    Vector2 wayPoint;

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

        if(distanceToPlayer > stopDistance)
        {
            if (distanceToPlayer < agroRange)
            {
                Chase();
            }
            else
            {
                Wander();
            }
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
        if (Vector2.Distance(transform.position, wayPoint) < wanderRange)
        {
            SetPath(); //setting new path here

        }
    }

    void SetPath()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance)); //setting max distance that can boss wander

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Here is the player"); // shouldnt be the case >.<
        }
        else
        {
            Debug.Log("Whatever it is imma leave it alone cuz i am a smart AI");
            SetPath();
        }
    }
}