using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class Agent : MonoBehaviour
{
    public Health HealthCompo;

    protected virtual void Awake()
    {
        HealthCompo = transform.GetComponent<Health>();
        HealthCompo.DeadEvent.AddListener(Die);
    }


    protected virtual void Die()
    {
        
    }
}
