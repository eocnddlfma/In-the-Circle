using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    public Vector3 _direction;
    public int _amount;
    public int _damage;
    public int _modifiedDamage;
    public int _cooltime;
    public int _modifiedCooltime;
    public int _level;

    protected SkillManager _skillManager;

    private void Awake()
    {
        _skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
    }

    public virtual void StartAttack()
    {
        StartCoroutine(Attacking());
    }
    
    public void SetDirection()
    {
        Vector3 myPos = transform.position;
        Vector3 targetPosition = _skillManager.GetTargetPosition();
        
        _direction = (targetPosition - myPos).normalized;
        if(_direction==Vector3.zero) _direction = Vector3.left;
    }
    
    IEnumerator Attacking()
    {
        while (true)
        {
            SetDirection();
            StartCoroutine(AttackPattern());
            yield return new WaitForSeconds((_cooltime-_modifiedCooltime)*((100-_skillManager._extraCooltimeReduce)/100f));
        }
    }

    public float GetDamage()
    {
        return (_damage + _modifiedDamage) * _skillManager._damageMultiplier;
    }
    
    public virtual IEnumerator AttackPattern()
    {
        yield return null;
    }
    public virtual void Upgrade()
    {
        
    }
}
