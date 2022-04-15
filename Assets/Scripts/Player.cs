using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private static Player _instance;
    public static Player player
    {
        get
        {
            _instance = GameObject.FindObjectOfType<Player>();
            if(_instance == null)
            {
                GameObject pl = Instantiate(Resources.Load("Player") as GameObject);
                if(pl != null)
                {
                    _instance = pl.GetComponent<Player>();

                }
                else
                {
                    Debug.Log("Error instantiating the player");
                }
            }
            DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }
    }
        


    public float speed = 6.0f;

    public AudioClip LowHealth;
    public AudioClip PlayerDeathSound;

    Gun gun;
    public bool diagonalShooting = false;


    public GameObject GunPrefab;

    Animator animator;

    public float health = 100.0f;

    [SerializeField]
    public string Scenename;

    [SerializeField]
    GameObject cameraPrefab;

    //  Directions:
    public Vector3 moveDirection;
    Vector3 shootDirection;

    // loot mechanic
    public int coins;

    //  Adjusting spawn position for gun
    Vector3 gunDisplacement = new Vector3(0.0f, 0.8f, 0.0f);
    void Awake()
    {
        GameObject gunObj = Instantiate(GunPrefab, transform.position + gunDisplacement, Quaternion.identity);    //  Create a gun from prefab
        gunObj.transform.parent = gameObject.transform;                                         //  Make it as a child of the player
        gun = gunObj.GetComponent<Gun>();                                                       //  Get reference to gun script

        GameObject sprite = gameObject.transform.GetChild(0).gameObject;
        animator = sprite.GetComponent<Animator>();
        if(!animator)
        {
            Debug.Log("No animator attached to player");
        }

        Instantiate(cameraPrefab, transform.position, Quaternion.identity);    //  Instantiate a camera from prefab
    }

    void Start()
    {
        
        moveDirection = new Vector3(0.0f, 0.0f, 0.0f);
        shootDirection = new Vector3(0.0f, 0.0f, 0.0f);
    }

    
    void Update()
    {
        CheckInput();

        Death();
    }


    public void Death()
    {
        if (health <= 0)
        {
            //Destroy(gameObject);    //  RIP F
            //respawn in Hub
            AudioManager.Instance.Play(PlayerDeathSound);
            SceneManager.LoadScene(Scenename);
            health = 100;

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

        if(moveDirection.magnitude > 0.1)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        transform.position += moveDirection * speed * Time.deltaTime;    //  Apply movement


        float sx = Input.GetAxis("ShootHorizontal"); //  Get input
        float sy = Input.GetAxis("ShootVertical");
        if (sx != 0 || sy != 0) //  Check for shooting input
        {
           
            if (UI_Shop.shop == null || UI_Shop.shop.ShopShown == false)
            {
                gun.Shoot(sx, sy);
            }
            
        }

    }

    public void GetDamage(float hp)
    {
        health -= hp;   // Does it need any explanation? 
        if (health < 25.0f)
        {
            AudioManager.Instance.Play(LowHealth);
        }
    }

    
    public void EquipWeapon()
    {
        if(gun.gameObject)
        {
            Destroy(gun.gameObject);
        }

        GameObject gunObj = Instantiate(GunPrefab, transform.position, Quaternion.identity);
        gunObj.transform.parent = gameObject.transform;
        gun = gunObj.GetComponent<Gun>();
    }
}
