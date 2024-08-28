using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFourSpin : AvoidBullet
{
    private Vector3 _direction;
    protected override void Start()
    {
        base.Start();
        _direction = (TargetTransform.position - MovingTransform.position).normalized;
    }

    public override void Pattern()
    {
        MovingTransform.Translate(_direction * (moveSpeed * Time.deltaTime));
        SpinTransform.Rotate(new Vector3(0,0, spinSpeed * Time.deltaTime));
    }
}
