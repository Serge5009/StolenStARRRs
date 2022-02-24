using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 speed;
    float lifetime = 0.0f;      //  Self destruct timer
    float lifeExpect = 5.0f;    //  Over this time bullet will die
    float damage = 10.0f;


    //  Interaction settings:
    [SerializeField]
    bool damagePlayer = false;      //  Will deal damage to the player?
    [SerializeField]
    bool destroyByPlayer = true;    //  Will dissapear after colliding with player?
    [SerializeField]
    bool destroyByObstacle = true;    //  Will dissapear after colliding with obstacle?

    [SerializeField]
    bool damageEnemy = true;        //  Will deal damage to the enemy?
    [SerializeField]
    bool destroyByEnemy = true;     //  Will dissapear after colliding with enemy?

    void Start()
    {
    }

    public void SetSpeed(Vector3 startVelocity)
    {
        speed = startVelocity;
    }

    public void SetInteraction(bool dmgPlayer, bool dmgEnemy, bool destPlayer, bool destEnemy)
    {
        damagePlayer = dmgPlayer;
        damageEnemy = dmgEnemy;
        destroyByPlayer = destPlayer;
        destroyByEnemy = destEnemy;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime;

        lifetime += Time.deltaTime; //  Bullet life timer cound
        if(lifetime >= lifeExpect)
            Destroy(gameObject);
    }

    
    void OnTriggerEnter2D(Collider2D coll)  //  Triger callback
    {
        if(coll.transform.tag == "Enemy")   //  If hitted the enemy
        {
            //Debug.Log("Boom!");
            Enemy other = coll.gameObject.GetComponent<Enemy>();    //  Getting the enemy object of our hit target

            if(damageEnemy)
            {
                other.GetDamage(damage);        //  Dealing damage to the enemy
            }
            if(destroyByEnemy && lifetime > 0.05f)  //  Bullet is immortal first fraction of a second
            {
                Destroy(gameObject);    //  Destroy this bullet
            }
        }
        else if (coll.transform.tag == "Player")
        {
            Player other = coll.gameObject.GetComponent<Player>();  //  Getting the player object of our hit target

            if(damagePlayer)
            {
                other.GetDamage(damage);
            }

            if(destroyByPlayer && lifetime > 0.05f)  //  Bullet is immortal first fraction of a second
            {
                Destroy(gameObject);    //  Destroy this bullet
            }
        }
        else if (coll.transform.tag == "Obstacle" && destroyByObstacle) //  This one is for future!!!
        {
            Destroy(gameObject);    //  Destroy this bullet
        }
        else
        {
            Destroy(gameObject);    //  Destroy this bullet
        }
    }
    
}
