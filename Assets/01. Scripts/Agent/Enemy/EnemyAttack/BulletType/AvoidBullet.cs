using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidBullet : BaseBullet
{
    public override void Setting()
    {
        base.Setting();
        isAttackerEnemy = true;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (isAttackable)
        {
            //print(transform);
            DoDamage(other);
            if (destroyWhenHit)
            {
                Destroy(gameObject);
            }
        }
    }

}
