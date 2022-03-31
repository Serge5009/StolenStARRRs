using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager lManager;

    GameObject[] spawners;

    //  Tracking

    int totalSpawned;
    int alive;

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
        spawners = GameObject.FindGameObjectsWithTag("Spawner");

        Debug.Log(spawners.Length);
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

        if (alive > 0)
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