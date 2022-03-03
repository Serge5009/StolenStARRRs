using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public float speed = 6.0f;

    [SerializeField]
    Gun gun;

    public float health = 100.0f;


    //  Directions:
    public Vector3 moveDirection;
    Vector3 shootDirection;

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

        if (health <= 0)
        {
            Destroy(gameObject);    //  RIP F
        }
    }

    void CheckInput()
    {

        float x = Input.GetAxis("Horizontal"); //  Get input
        float y = Input.GetAxis("Vertical");

        moveDirection = new Vector3(x, y, 0);   //  Get direction vector

        if (moveDirection.magnitude > 1) //  Limit this vector magnitude to 1
        {
            moveDirection = moveDirection / moveDirection.magnitude;
        }

        //Debug.Log(moveDirection);
        //Debug.Log(moveDirection.magnitude);

        transform.position += moveDirection * speed * Time.deltaTime;    //  Apply movement


        float sx = Input.GetAxis("ShootHorizontal"); //  Get input
        float sy = Input.GetAxis("ShootVertical");
        if (sx != 0 || sy != 0) //  Check for shooting input
        {
            gun.Shoot(sx, sy);
        }

    }

    

    public void GetDamage(float hp)
    {
        health -= hp;   // Does it need any explanation? 
    }

}
