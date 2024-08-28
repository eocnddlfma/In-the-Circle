using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillShoot : BaseSkill
{
    public float _moveSpeed;
    public GameObject AttackBullet;
    void Start()
    {
        Upgrade();
        StartAttack();
    }

    public override void StartAttack()
    {
        base.StartAttack();
    }

    public override void Upgrade()
    {
        base.Upgrade();
        switch (_level)
        {
            case 0:
                _amount = 1;
                _damage = 1;
                _cooltime = 1;
                _moveSpeed = 30;
                break;
            case 1:
                _amount=2;
                _modifiedCooltime = _cooltime / 8;
                break;
            case 2:
                _moveSpeed += 10;
                _modifiedDamage = _damage * 3;
                break;
            case 3:
                _amount=3;
                _modifiedCooltime = _cooltime / 5;
                break;
            case 4:
                _modifiedCooltime = _cooltime / 3;
                _modifiedDamage = _damage * 5;
                _moveSpeed += 5;
                break;
        }

        _level++;
    }

    public override IEnumerator AttackPattern()
    {
        for (int i = 0; i < _amount + _skillManager._extraAmountAttack; i++)
        {
            Instantiate(AttackBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    
}
