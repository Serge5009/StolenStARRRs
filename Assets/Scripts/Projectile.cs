using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 speed;
    float lifetime = 0.0f;      //  Self destruct timer
    [SerializeField]
    float lifeExpect = 5.0f;    //  Over this time bullet will die

    public float damage = 10.0f; 

    
    //  Interaction settings:

    [SerializeField]
    bool destroyByPlayer = true;    //  Will dissapear after colliding with player?
    [SerializeField]
    bool destroyByEnemy = true;     //  Will dissapear after colliding with enemy?
    [SerializeField]
    bool destroyByObstacle = true;    //  Will dissapear after colliding with obstacle?
    [SerializeField]
    protected bool destroyByBullet = false;    //  Will dissapear after colliding with another bullet?

    public bool damagePlayer = false;      //  Will deal damage to the player?
    public bool damageEnemy = true;        //  Will deal damage to the enemy?
    [SerializeField]
    bool destroyOtherBullets = false;    //  Will delete another bullet on collision?

    //  Other types
    [HideInInspector]
    public bool isExplosive = false;    //  Will be automatically set to true if explosive script is attached

    
    protected void Start()
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

    protected void Update()
    {
        transform.position += speed * Time.deltaTime;

        lifetime += Time.deltaTime; //  Bullet life timer cound
        if(lifetime >= lifeExpect)
            Destroy(gameObject);
    }

    
    void OnTriggerEnter2D(Collider2D coll)  //  Triger callback
    {
        if(isExplosive) //  For other bullet type
        {
            //Debug.Log("Boom!");
            Explosive explScript = GetComponent<Explosive>();
            explScript.Explode();

            return;
        }

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
        else if (coll.transform.tag == "Obstacle") //  This one is for future!!!
        {
            if(destroyByObstacle)
                Destroy(gameObject);    //  Destroy this bullet
        }
        else if (coll.transform.tag == "Projectile")
        {
            if(destroyOtherBullets)
            {
                Destroy(coll.gameObject);
            }

            if (destroyByBullet)
            {
                Destroy(gameObject);    //  Destroy this bullet
            }
        }
        else
        {
            Destroy(gameObject);    //  Destroy this bullet
        }
    }
    
}
