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

    [SerializeField]        //  0 - all bullets fly in one direction | 1 - 360 degree scatter
    float scatter = 0.01f;  //  Reccomended values between 0 and 0.3

    GameObject player;

    Vector3 shootDirection;
    float cooldown;


    void Start()
    {
        fireRate += Random.Range(fireRate / -5, fireRate / 5);  //  Randomizing firerate
        cooldown = 1 / fireRate;
        player = GameObject.FindGameObjectWithTag("Player");
        if(!player)
        {
            Debug.Log("Enemy couldn't locate player");
        }
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
        shootDirection = Vector3.Normalize(shootDirection);

        //  Apply scatter
        float x = Random.Range(scatter * -1, scatter);
        float y = Random.Range(scatter * -1, scatter);
        shootDirection += new Vector3(x, y, 0.0f);

    }
}
