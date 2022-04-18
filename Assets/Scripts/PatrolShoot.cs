using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolShoot : MonoBehaviour
{

    // almost the same ode of Serhi`s Enemy Shoot script

    [SerializeField]
    GameObject ProjectilePrefab;
    [SerializeField]
    float bulletSpeed = 10.0f;
    [SerializeField]
    float fireRate = 1.0f;  //  Bullets per second

    [SerializeField]        //  0 - all bullets fly in one direction | 1 - 360 degree scatter
    float scatter = 0.01f;  //  Reccomended values between 0 and 0.3

    

    Vector3 shootDirection;
    float cooldown;

    [SerializeField]
    float agroRange;
    private Transform target;
    void Start()
    {
       // fireRate += Random.Range(fireRate / -5, fireRate / 5);  //  Randomizing firerate
        cooldown = 1 / fireRate;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.GetComponent<Transform>();
        if (player == null)
        {
            Debug.Log("Enemy couldn't locate player");
        }
    }

    void Update()
    {

        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            target = player.GetComponent<Transform>();
            if (player == null)
            {
                Debug.Log("Enemy couldn't locate player");
            }
        }
        else
        {
            cooldown -= Time.deltaTime; //  Tick cooldown timer
            if (cooldown <= 0)
            {
                Fire();
            }
        }
       

    }


    void Fire()
    {

        cooldown += 1 / fireRate; // coldown outside if statement so enemy will not shoot multiple bullets 
        if (Vector2.Distance(transform.position, target.position) < agroRange) // setting agro range here
        {
            Aim();

            GameObject proj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Projectile bullet = proj.GetComponent<Projectile>();

            bullet.SetSpeed(shootDirection * bulletSpeed);
        }

    }

    void Aim()
    {
        shootDirection = target.position - transform.position;
        shootDirection = Vector3.Normalize(shootDirection);

        //  Apply scatter
        float x = Random.Range(scatter * -1, scatter);
        float y = Random.Range(scatter * -1, scatter);
        shootDirection += new Vector3(x, y, 0.0f);

    }
}
