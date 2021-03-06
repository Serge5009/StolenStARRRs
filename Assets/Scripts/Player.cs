using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public enum GUN_TYPES
    {
        HEAVY_GUN,
        LIGHT_GUN,
        MELEE_GUN,

        NUM_GUN_TYPES
    }


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

    public GUN_TYPES activeGun = GUN_TYPES.LIGHT_GUN;                               //  Active gun ID
    //public GameObject GunPrefab;        //  IMPORTANT!!! THIS IS TO BE DELETED!!!                                   !!!!!
    public GameObject[] GunPrefabs = new GameObject[(int)GUN_TYPES.NUM_GUN_TYPES];  //  List of owned guns that can be used in this run


    Animator animator;

    public float health = 100.0f;

    [SerializeField]
    public string Scenename;

    [SerializeField]
    GameObject cameraPrefab;
    [SerializeField]
    Vector3 cameraPosition;
    [SerializeField]
    float maxCameraDistance = 30;
    [SerializeField]
    float cameraSpeed = 2.0f;
    [HideInInspector]
    public GameObject mainCamera;

    //  Directions:
    public Vector3 moveDirection;
    Vector3 shootDirection;

    // loot mechanic
    public int coins;

    //  Adjusting spawn position for gun
    Vector3 gunDisplacement = new Vector3(0.0f, 0.0f, 0.0f);

    DamageParticle particles;

    void Awake()
    {
        EquipWeapon();

        GameObject sprite = gameObject.transform.GetChild(0).gameObject;
        animator = sprite.GetComponent<Animator>();
        if(!animator)
        {
            Debug.Log("No animator attached to player");
        }

        particles = gameObject.GetComponent<DamageParticle>();
        if (!particles)
            Debug.Log("No particle spawner attached to player");

        if(GunPrefabs.Length != ((int)GUN_TYPES.NUM_GUN_TYPES))
        {
            Debug.Log("Wrong number of guns attached to the player");
        }

        //mainCamera = Instantiate(cameraPrefab, transform.position + cameraPosition, Quaternion.identity);    //  Instantiate a camera from prefab
    }

    void Start()
    {       
        moveDirection = new Vector3(0.0f, 0.0f, 0.0f);
        shootDirection = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        if(mainCamera == null)  //  Fixing level transitions
        {
            SpawnCamera();
        }

        CheckInput();
        Death();
        Debug.Log("player health:  " + health);
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    void SpawnCamera()
    {
        mainCamera = Instantiate(cameraPrefab, transform.position + cameraPosition, Quaternion.identity);    //  Instantiate a camera from prefab
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

        //  Gun switch
        if(Input.GetKeyDown("e"))
        {
            SwitchWeapon(true);
        }
        else if (Input.GetKeyDown("q"))
        {
            SwitchWeapon(false);
        }
    }

    public void GetDamage(float hp)
    {
        health -= hp;   // Does it need any explanation? 
        if (health < 25.0f)
        {
            AudioManager.Instance.Play(LowHealth);
        }

        particles.OnGetDamage();    //  Call damage particle spawn
    }


    public void EquipWeapon()
    {
        if(gun != null)     //  If gun exists - delete it
        {
            Destroy(gun.gameObject);
        }

        GameObject gunObj = Instantiate(GunPrefabs[((int)activeGun)], transform.position + gunDisplacement, Quaternion.identity);   //  Create a gun from prefab
        gunObj.transform.parent = gameObject.transform;                                                                             //  Make it as a child of the player
        gun = gunObj.GetComponent<Gun>();                                                                                           //  Get reference to gun script
    }

    void SwitchWeapon(bool side)    //  If side = true - will go down the list
    {
        if(side)
        {
            if (activeGun == GUN_TYPES.HEAVY_GUN)       //  Yeah, it's done by basic if/else's )))
                activeGun = GUN_TYPES.LIGHT_GUN;
            else if (activeGun == GUN_TYPES.LIGHT_GUN)
                activeGun = GUN_TYPES.MELEE_GUN;
            else if (activeGun == GUN_TYPES.MELEE_GUN)
                activeGun = GUN_TYPES.HEAVY_GUN;
            else
                Debug.Log("Error switching the gun!");
        }
        else
        {
            if (activeGun == GUN_TYPES.HEAVY_GUN)
                activeGun = GUN_TYPES.MELEE_GUN;
            else if (activeGun == GUN_TYPES.MELEE_GUN)
                activeGun = GUN_TYPES.LIGHT_GUN;
            else if (activeGun == GUN_TYPES.LIGHT_GUN)
                activeGun = GUN_TYPES.HEAVY_GUN;
            else
                Debug.Log("Error switching the gun!");
        }

        EquipWeapon();  //  Activate the new gun after it was selected
    }

    void CameraFollow()
    {
        var newPos = Vector2.Lerp(mainCamera.transform.position, transform.position, Time.deltaTime * cameraSpeed);
        mainCamera.transform.position = new Vector3(newPos.x, newPos.y, cameraPosition.z); ;
    }
}
