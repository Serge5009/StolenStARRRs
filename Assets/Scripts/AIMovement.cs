using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    float stopDistance = 1.0f;

    public float speed = 0.0f; // tokyo drift?
    private Transform target;

    Animator animator;

    void Awake()
    {
        GameObject sprite = gameObject.transform.GetChild(0).gameObject;
        animator = sprite.GetComponent<Animator>();
        if (!animator)
        {
            Debug.Log("No animator attached to enemy");
        }
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // here we are getting players location


                                                                                //  Randomization
        speed += Random.Range(speed / -5, speed / 5);                           //speed
        stopDistance += Random.Range(stopDistance / -5, stopDistance / 5);      //stop distance
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stopDistance)  // in order to avaoid collapsing with player
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // imma chase the poor player guy endlessly
            animator.SetBool("IsRunning", true);

        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

    }
}
