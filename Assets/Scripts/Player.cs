using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 6.0f;

    [SerializeField]
    GameObject ProjectilePrefab;

    Vector3 shootDirection;
    float bulletSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        CheckInput();
    }

    void SpawnProjectile()
    {
        GameObject proj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        Projectile bullet = proj.GetComponent<Projectile>();
        bullet.SetSpeed(new Vector3(1.0f, 0.0f, 0.0f));

    }

    void CheckInput()
    {

        float x = Input.GetAxis("Horizontal"); //  Get input
        float y = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(x, y, 0);   //  Get direction vector

        if(moveDirection.magnitude > 1) //  Limit this vector magnitude to 1
        {
            moveDirection = moveDirection / moveDirection.magnitude;
        }

        //Debug.Log(moveDirection);
        //Debug.Log(moveDirection.magnitude);

        transform.position += moveDirection * speed * Time.deltaTime;    //  Apply movement

        
        if(Input.GetButtonDown("Jump"))
        {
            SpawnProjectile();
            Debug.Log("Pew");
        }    

    }
}
