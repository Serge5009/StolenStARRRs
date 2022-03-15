using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : Projectile
{
    [SerializeField]
    float safeTime = 0.4f;

    [SerializeField]
    float expTriggerRad;

    CircleCollider2D coll;



    void Start()
    {
        base.Start();
        destroyByBullet = true;

        coll = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        coll.radius = expTriggerRad;
    }

    void Update()
    {
        base.Update();
        
    }
}
