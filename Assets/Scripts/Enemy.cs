using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 100.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if(health <= 0)
            Destroy(gameObject);    //  RIP
    }

    public void GetDamage(float hp)
    {
        health -= hp;   // Does it need any explanation?
    }
}
