using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    GameObject ProjectilePrefab;
    [SerializeField]
    float bulletSpeed = 10.0f;
    [SerializeField]
    float fireRate = 1.0f;  //  Bullets per second

    [SerializeField]        //  0 - all bullets fly in one direction | 1 - 360 degree scatter
    float scatter = 0.01f;  //  Reccomended values between 0 and 0.3

    [SerializeField]
    GameObject bulletSpawn; //  Place where projectiles start their movement from (barrel end)

    //  Private:

    Vector3 shootDirection;
    float cooldown;

    int shootHeat = -1; //  Countdown used to fire gun 1 frame after rotation. Prevents bullet from spawning on old barrel location


    void Start()
    {
        player = transform.parent.gameObject;
    }

    void Update()
    {
        cooldown -= Time.deltaTime; //  Tick cooldown timer

        if (cooldown < 0)
            cooldown = 0;   //  Prevent negative values

        shootHeat -= 1;
        if (shootHeat == 0)
        {
            SpawnProjectile(shootDirection);    //  Shoot
            shootHeat = -1;
        }
    }

    public void Shoot(float shootX, float shootY)
    //  I'm using Vector3 here to leave space for possible diagonal shooting in future
    {
        RotateGun();
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

            shootHeat = 2;   //  On the next frame gun will shoot
        }
    }

    void SpawnProjectile(Vector3 direction)
    {
        //  Apply scatter
        float x = Random.Range(scatter * -1, scatter);
        float y = Random.Range(scatter * -1, scatter);
        direction += new Vector3(x, y, 0.0f);


        //  Spawn bullet
        GameObject proj = Instantiate(ProjectilePrefab, bulletSpawn.transform.position, Quaternion.identity);
        Projectile bullet = proj.GetComponent<Projectile>();
        Player parent = player.GetComponent<Player>();

        bullet.SetSpeed(direction * bulletSpeed + parent.moveDirection * parent.speed);
        bullet.SetInteraction(false, true, true, true);
    }

    void RotateGun()
    {   //  Rotates gun in the direction of a shoot
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, shootDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500.0f);      //  Source: https://www.youtube.com/watch?v=gs7y2b0xthU
    }


}
