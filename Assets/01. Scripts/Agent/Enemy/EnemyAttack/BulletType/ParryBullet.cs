using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryBullet : BaseBullet
{
    public void DoParry()
    {
        TargetTransform = ParentTransform;
        isAttackerEnemy = !isAttackerEnemy;
        PatternSetting();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other); 
        if (other.TryGetComponent(out Health HealthCompo))
        {
            if (isAttackable)
            {
                DoDamage(other);
                if (destroyWhenHit)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
