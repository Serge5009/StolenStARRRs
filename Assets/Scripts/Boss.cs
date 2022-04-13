using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : Enemy
{
    [SerializeField]
    float[] phaseHP;
    int currentPhase = 0;
    public UnityEvent phaseCallbacks;

    //  Start is called before the first frame update
    void Start()
    {
        base.Start();
        health = 1; //  health is not used by boss, so it's now set to 1 by default
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if(phaseHP[currentPhase] <= 0)
        {
            NextPhase();
        }
    }

    void NextPhase()
    {
        currentPhase++;
        Debug.Log("Phase " + currentPhase + " is done!");

        if(currentPhase >= phaseHP.Length)
        {
            Destroy(gameObject);    //  RIP F
        }

        phaseCallbacks.Invoke();
    }

    public override void GetDamage(float hp)
    {
        phaseHP[currentPhase] -= hp;
        //Debug.Log("Current phase is " + currentPhase + " Health is " + phaseHP[currentPhase]);
    }
}
