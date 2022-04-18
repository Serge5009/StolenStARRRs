using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject[] particlePrefab;
    [SerializeField] float[] weight;

    [SerializeField] int minParticles;
    [SerializeField] int maxParticles;

    [SerializeField] float lifetime = 0.5f;
    float timer = 0.0f;

    void Start()
    {
        if (weight.Length != particlePrefab.Length)
        {
            Debug.Log("Attention!!! Weight and particlePrefab arrays MUST be the same lenght");
        }

        int numDrops = Random.Range(minParticles, maxParticles);
        for (int i = 0; i < numDrops; i++)   //  Multiple drops
            SpawnParticle();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > lifetime)
        {
            Destroy(gameObject);
        }
    }

    void SpawnParticle()
    {
        float weigtSum = 0;       //  Get a sum of all weight for drops
        foreach (float i in weight)
            weigtSum += i;

        float randInt = Random.Range(0, weigtSum);  //  Get a random value between 0 and weight sum

        bool isParticleFound = false;
        int acriveParticle = 0;

        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0.01f);  //  Adjusting Z axis to spawn behing the obstacles

        while (!isParticleFound)    //  Loop thru all positions untill got a match
        {
            if (weight[acriveParticle] > randInt)    //  If random value is within this prefab's weight
            {
                isParticleFound = true;
                Instantiate(particlePrefab[acriveParticle], spawnPos, Quaternion.identity);   //  Spawn drop
            }
            else
            {
                randInt -= weight[acriveParticle];  //  Move to next option
                acriveParticle++;
            }
        }
    }
}
