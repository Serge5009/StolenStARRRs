using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController lController;

    [SerializeField]
    GameObject SpawnPoint;
    Vector3 spawnPoint;

    //public transform playerSpawn;

    void Awake()
    {
        if (lController != null)
        {
            Destroy(lController.gameObject);
            lController = this;
        }
        else
        {
            lController = this;
        }
    }

    void Start()
    {
        spawnPoint = SpawnPoint.transform.position;
        if(!SpawnPoint)
        {
            Debug.Log("Failed to find the spawnpoint");
        }
        if(Player.player != null)
        {
            Player.player.transform.position = spawnPoint;
        }
        else
        {
            Debug.Log("Failed to find the player");
        }

    }
}
