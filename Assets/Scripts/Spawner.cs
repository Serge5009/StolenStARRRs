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
    float activationDistance = 10.0f;

    [SerializeField]
    GameObject EnemyPrefab;

    public bool isWorking = true;
    bool isActivated = false;

    void Start()
    {
        timer = spawnRate;
    }

    void Update()
    {
        if(isWorking && isActivated)
            timer -= Time.deltaTime;    //  Timer works only if spawner is activated

        if(!isActivated)
        {
            float distance = Vector3.Distance(Player.player.transform.position, transform.position);
            if (distance < activationDistance)
                isActivated = true;
        }    

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
        LevelManager.lManager.OnNewSpawned();
    }

}
