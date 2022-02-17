using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 6.0f;
    public static Player player;


    public float speed = 6.0f;

    [SerializeField]
    GameObject ProjectilePrefab;

    [SerializeField]
    float bulletSpeed = 10.0f;    
    [SerializeField]
    float fireRate = 1.0f;  //  Bullets per second

    //  Private:
    Vector3 moveDirection;
    Vector3 shootDirection;

    float cooldown;
    // loot mechanic
    public int coins;

    void Awake()
    {
        if(player != null)
        {
            Destroy(player);
        }
        else
        {
            player = this;
        }
    }

    void Start()
    {
        moveDirection = new Vector3(0.0f, 0.0f, 0.0f);
        shootDirection = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        CheckInput();
    }

    void SpawnProjectile(Vector3 direction) 
        //  I'm using Vector3 here to leave space for possible diagonal shooting in future
    {
        GameObject proj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        Projectile bullet = proj.GetComponent<Projectile>();
        bullet.SetSpeed(direction * bulletSpeed + moveDirection * speed);

    }

    void CheckInput()
    {

        float x = Input.GetAxis("Horizontal"); //  Get input
        float y = Input.GetAxis("Vertical");

        moveDirection = new Vector3(x, y, 0);   //  Get direction vector

        if(moveDirection.magnitude > 1) //  Limit this vector magnitude to 1
        {
            moveDirection = moveDirection / moveDirection.magnitude;
        }

        //Debug.Log(moveDirection);
        //Debug.Log(moveDirection.magnitude);

        transform.position += moveDirection * speed * Time.deltaTime;    //  Apply movement


        float sx = Input.GetAxis("ShootHorizontal"); //  Get input
        float sy = Input.GetAxis("ShootVertical");



        cooldown -= Time.deltaTime; //  Tick cooldown timer

        if (cooldown < 0)
            cooldown = 0;   //  Prevent negative values


        if (sx != 0 || sy != 0) //  Check for shooting input
        {
            if (sy > 0) //  Set shooting direction vector
            {
                shootDirection = new Vector3(0.0f, 1.0f, 0.0f);
            }
            else if (sy < 0)
            {
                shootDirection = new Vector3(0.0f, -1.0f, 0.0f);
            }
            if (sx > 0)
            {
                shootDirection = new Vector3(1.0f, 0.0f, 0.0f);
            }
            else if(sx < 0)
            {
                shootDirection = new Vector3(-1.0f, 0.0f, 0.0f);
            }
            //Debug.Log(shootDirection);

            if(cooldown == 0)
            {
                cooldown += 1/fireRate;             //  Reset cooldown
                SpawnProjectile(shootDirection);    //  Shoot
            }
        }

    }
}
