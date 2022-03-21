using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager lManager;

    GameObject[] spawners;

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


}