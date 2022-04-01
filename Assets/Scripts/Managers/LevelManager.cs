using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager lManager;

            //  Player spawn
    [SerializeField]
    GameObject PlayerSpawnPoint;
    Vector3 spawnPoint;

            //  Enemy spawn
    GameObject[] spawners;

    //  Tracking

    int totalSpawned;
    int alive;
    [HideInInspector]
    public int activeSpawners = 0;

    [SerializeField]
    int toSpawn = 20;
    [SerializeField]
    int maxAlive = 10;

    [SerializeField]
    GameObject LazerWalls;

    void Awake()
    {
        if (lManager != null)
        {
            Destroy(lManager);
            lManager = this;
        }
        else
        {
            lManager = this;

        }
        if (!LazerWalls)
            Debug.Log("No lazers attached to Level manager!");
          
    }

    void Start()
    {
        //  Spawn player
        spawnPoint = PlayerSpawnPoint.transform.position;
        if (!PlayerSpawnPoint)
        {
            Debug.Log("Failed to find the spawnpoint");
        }
        if (Player.player != null)
        {
            Player.player.transform.position = spawnPoint;
        }
        else
        {
            Debug.Log("Failed to find the player");
        }

        //  Set up enemy spawners
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        Debug.Log("Spawners on this level: " + spawners.Length);
    }

    void Update()
    {
        if(alive >= maxAlive || totalSpawned >= toSpawn)    //  Controls pausing/unpausing for enemy spawners                        
        {
            PauseSpawners();
        }
        if(alive < maxAlive && totalSpawned <= toSpawn)
        {
            UnauseSpawners();
        }

        if (activeSpawners > 0 || alive > 0)
            LazerWalls.SetActive(true);
        else
            LazerWalls.SetActive(false);

    }

    void PauseSpawners()
    {
        foreach(GameObject spawn in spawners)
        {
            Spawner sp = spawn.GetComponent<Spawner>();
            sp.isWorking = false;
        }
    }

    void UnauseSpawners()
    {

    }

    public void OnNewSpawned()
    {
        totalSpawned += 1;
        alive += 1;
    }

    public void OnEnemyDeath()
    {
        alive -= 1;
    }
}