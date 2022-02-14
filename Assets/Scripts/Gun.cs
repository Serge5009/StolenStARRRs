using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject ProjectilePrefab;
    [SerializeField]
    float bulletSpeed = 10.0f;
    [SerializeField]
    float fireRate = 1.0f;  //  Bullets per second



    //  Private:

    Vector3 shootDirection;
    float cooldown;


    void Start()
    {
        
    }

    void Update()
    {
        cooldown -= Time.deltaTime; //  Tick cooldown timer

        if (cooldown < 0)
            cooldown = 0;   //  Prevent negative values



    }

    public void Shoot(float shootX, float shootY)
    //  I'm using Vector3 here to leave space for possible diagonal shooting in future
    {
        if (shootY > 0) //  Set shooting direction vector
        {
            shootDirection = new Vector3(0.0f, 1.0f, 0.0f);
        }
        else if (shootY < 0)
        {
            shootDirection = new Vector3(0.0f, -1.0f, 0.0f);
        }
        if (shootX > 0)
        {
            shootDirection = new Vector3(1.0f, 0.0f, 0.0f);
        }
        else if (shootX < 0)
        {
            shootDirection = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        //Debug.Log(shootDirection);

        if (cooldown == 0)
        {
            cooldown += 1 / fireRate;             //  Reset cooldown

            SpawnProjectile(shootDirection);    //  Shoot
        }



    }

    void SpawnProjectile(Vector3 direction)
    {
        GameObject proj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        Projectile bullet = proj.GetComponent<Projectile>();
        Player parent = player.GetComponent<Player>();

        bullet.SetSpeed(direction * bulletSpeed + parent.moveDirection * parent.speed);


    }

}
