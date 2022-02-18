using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float spawnRate = 10.0f;    //  Seconds between spawn
    float timer;

    [SerializeField]
    static int maxEnemies = 10; //  To be implemented
    static int currentEnemies = 0;  //  We start with 2 now

    [SerializeField]
    GameObject EnemyPrefab;

    void Start()
    {
        timer = spawnRate;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = spawnRate;
            Spawn();
        }
    }

    void Spawn()
    {
        Debug.Log("New");
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
    }

}
