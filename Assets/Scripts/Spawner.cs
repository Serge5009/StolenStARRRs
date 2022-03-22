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
    int burstSpawn = 4;

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
                Activate();
        }    

        if(timer <= 0)
        {
            timer = spawnRate;
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        float delay = Random.Range(0.0f, spawnRate);
        yield return new WaitForSeconds(delay);
        Debug.Log("New");
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        LevelManager.lManager.OnNewSpawned();
    }

    void Activate()
    {
        isActivated = true;
        for (int i = 0; i < burstSpawn; i++)    //Spawn first enemies
            StartCoroutine(Spawn());
    }

}
