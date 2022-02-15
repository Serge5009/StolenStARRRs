using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 speed;
    float lifetime = 5.0f;  //  Self destruct timer
    float damage = 10.0f;   
   
    void Start()
    {
    }

    public void SetSpeed(Vector3 startVelocity)
    {
        speed = startVelocity;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime;

        lifetime -= Time.deltaTime; //  Countdown to self destruct
        if(lifetime <= 0)
            Destroy(gameObject);
    }

    /*
    void OnTriggerEnter2D(Collider2D coll)  //  Triger callback
    {
        if(coll.transform.tag == "Enemy")   //  If hitted the enemy
        {
            //Debug.Log("Boom!");
            Enemy other = coll.gameObject.GetComponent<Enemy>();    //  Getting the enemy object of our hit target
            other.GetDamage(damage);        //  Dealing damage to the enemy
        }

        Destroy(gameObject);    //  Destroy this bullet
    }
    */
}
