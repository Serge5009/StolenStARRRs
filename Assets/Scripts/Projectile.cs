using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 speed;

    void Start()
    {
        //speed = new Vector3(1.0f, 0.0f, 0.0f);
    }

    public void SetSpeed(Vector3 startVelocity)
    {
        speed = startVelocity;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime;
    }
}
