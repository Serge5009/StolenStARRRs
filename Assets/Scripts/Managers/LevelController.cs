using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController lController;

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

        if(Player.player == null)
        {
            //Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
        }

    }
}
