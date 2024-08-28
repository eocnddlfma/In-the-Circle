using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryGuidedArrow : ParryBullet
{
    public float GuidedTime;
    
    private Vector3 _direction;
    private Vector3 _moveDirection;
    private Vector3 _befDirection;
    protected override void Start()
    {
        base.Start();
    }

    public override void PatternSetting()
    {
        base.PatternSetting();
        StartCoroutine(KeepGuided());
        _befDirection = (TargetTransform.position - MovingTransform.position).normalized;
    }

    public override void Pattern()
    {
        MovingTransform.Translate(_moveDirection.normalized * (moveSpeed * Time.deltaTime));
    }

    IEnumerator KeepGuided()
    {
        float time = 0;
        while (time < GuidedTime)
        {
        _direction = (TargetTransform.position - MovingTransform.position).normalized;
        _moveDirection = _direction + _befDirection;
        _befDirection = _direction;
        yield return null;
        time += Time.deltaTime;
        }
    }
}
