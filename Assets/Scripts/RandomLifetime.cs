using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLifetime : MonoBehaviour
{
    [SerializeField] float minTime = 0.0f;
    [SerializeField] float maxTime = 1.0f;
    float lifetime;
    float timer = 0.0f;

    void Start()
    {
        lifetime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
