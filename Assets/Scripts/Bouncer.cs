using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  This script makes object fly into the air and fall on the ground on spawn
//  Used for visual effects

public class Bouncer : MonoBehaviour
{
    [SerializeField] bool activateOnSpawn = true;

    [SerializeField] float maxHorizontal;
    [SerializeField] float minVertical;
    [SerializeField] float maxVertical;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float minDown = 0.0f;
    [SerializeField] float maxDown = 0.0f;
    float fallDown;

    bool isBouncing = false;

    Vector3 speed;
    Vector3 startingPosition;

    void Start()
    {
        if (activateOnSpawn)
            Bounce();

        if(minDown > 0)
        {
            minDown = 0;
            Debug.Log("Shouldn't set falling distance to Values > 0");
        }
        if (maxDown > 0)
        {
            maxDown = 0;
            Debug.Log("Shouldn't set falling distance to Values > 0");
        }
    }

    void Update()
    {
        if (!isBouncing)    //  We want to use update only when moving the object
            return;

        speed.y -= gravity * Time.deltaTime;
        transform.position += speed * Time.deltaTime;

        float height = transform.position.y - startingPosition.y;
        //Debug.Log("Altitude: " + height);
        if (height < fallDown)
            isBouncing = false;
    }

    public void Bounce()
    {
        isBouncing = true;
        speed = new Vector3(Random.Range(-maxHorizontal, maxHorizontal), Random.Range(minVertical, maxVertical), 0.0f);
        fallDown = Random.Range(minDown, maxDown);
        startingPosition = transform.position;
    }
}
