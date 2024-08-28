using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBullet : BaseBullet
{
    [SerializeField]private float _damageInterval;
    public float lastAttackTime=0;
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (isAttackable)
        {
            if (other.transform == TargetTransform)
            {
                float currentTime = Time.time;
                if (lastAttackTime + _damageInterval > currentTime)
                {
                    lastAttackTime = currentTime;
                    DoDamage(other);
                }
            }   
        }
    }
}
