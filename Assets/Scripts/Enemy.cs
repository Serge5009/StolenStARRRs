using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 100.0f;
   
    public GameObject lootDrop;

    
    void Start()
    {
       
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);    //  RIP F
            Instantiate(lootDrop, transform.position, Quaternion.identity);
        }
            
       
    }

    public void GetDamage(float hp)
    {
        health -= hp;   // Does it need any explanation? 
    }
}
