using UnityEngine;

public class EnemyMobility : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private Vector3[] locations;

    [SerializeField]
    GameObject ProjectilePrefab;

    [SerializeField]
    float ProjectileSpeed = 5.0f;

    float cooldownTime = 2.0f;
    float nextFireTime;
    private int offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        transform.position = Vector2.MoveTowards(transform.position, locations[offset], Time.deltaTime * speed); // move to the pre determined points

        if(transform.position == locations[offset]) // if the location same
        {
            if( offset == locations.Length -1)
            {
                offset = 0; //restard the queue
            }
            else
            {
                offset++; // otherwise follow queue
            }
        }

        
        if (Time.time > nextFireTime)
        {

            RangeAttack();
            nextFireTime = Time.time + cooldownTime;

        }
    }

  
    void RangeAttack()
    {
        GameObject ready = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        //Vector3 direction = new Vector3(1.0f, 0.0f, 0.0f);
    }
    
    
}


