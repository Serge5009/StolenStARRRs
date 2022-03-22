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