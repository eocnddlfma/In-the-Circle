using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidStraightArrow : AvoidBullet
{
    private Vector3 _direction;
    
    
    protected override void Start()
    {
        base.Start();
    }

    public override void PatternSetting()
    {
        base.PatternSetting();
        _direction = (TargetTransform.position - MovingTransform.position).normalized;
    }

    public override void Pattern()
    {
        MovingTransform.Translate(_direction * (moveSpeed * Time.deltaTime));
    }
}
