using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 0.0f; // tokyo drift?
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // here we are getting players location
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 0.3)  // in order to avaoid collapsing with player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // imma chase the poor player guy endlessly
    }
}
