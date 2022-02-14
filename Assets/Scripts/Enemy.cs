using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 100.0f;
    public float speed = 0.0f; // tokyo drift?

    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // here we are getting players location
    }

    void Update()
    {
        if(health <= 0)
            Destroy(gameObject);    //  RIP F
        if(Vector2.Distance(transform.position, target.position) > 0.3)  // in order to avaoid collapsing with player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // imma chase the poor player guy endlessly
    }

    public void GetDamage(float hp)
    {
        health -= hp;   // Does it need any explanation? 
    }
}
