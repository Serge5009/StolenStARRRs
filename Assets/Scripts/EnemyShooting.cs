using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    GameObject ProjectilePrefab;
    [SerializeField]
    float bulletSpeed = 10.0f;
    [SerializeField]
    float fireRate = 1.0f;  //  Bullets per second

    GameObject player;

    Vector3 shootDirection;
    float cooldown;


    void Start()
    {
        cooldown = 1 / fireRate;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        cooldown -= Time.deltaTime; //  Tick cooldown timer

        if (cooldown <= 0)
            Shoot();
    }

    void Shoot()
    {
        Aim();

        cooldown += 1 / fireRate;

        GameObject proj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        Projectile bullet = proj.GetComponent<Projectile>();

        bullet.SetSpeed(shootDirection * bulletSpeed);
    }

    void Aim()
    {
        shootDirection = player.transform.position - transform.position;

    }
}
