using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShield : BaseSkill
{
    public GameObject ShieldPrefab;

    [SerializeField]private int _shieldAmount;
    [SerializeField]private float _shieldSpinSpeed;
    [SerializeField]private float _modifiedSpinSpeed;
    [SerializeField]private float _shieldDistance;
    
    public override void StartAttack()
    {
        base.StartAttack();
        SetShields();
    }
    public override IEnumerator AttackPattern()
    {
        transform.Rotate(0,0,(_shieldSpinSpeed+_modifiedSpinSpeed)*Time.deltaTime);
        yield return null;
    }

    public override void Upgrade()
    {
        switch (_level)
        {
            case 0:
                StartAttack();
                break;
            case 1:
                _shieldAmount++;
                break;
            case 2:
                _shieldDistance -= 0.5f;
                _modifiedSpinSpeed = _shieldSpinSpeed / 4;
                break;
            case 3:
                _shieldDistance -= 0.5f;
                break;
            case 4:
                _shieldAmount++;
                break;
        }
        _level++;
        SetShields();
    }

    public void SetShields()
    {
        int cnt = transform.GetChild(0).childCount;
        for (int i = 0; i < cnt; i++)
        {
            Destroy(transform.GetChild(0).GetChild(0));
        }
        for(int i=0; i<_shieldAmount+ SkillManager.Instance._extraAmountAttack;i++)
        {
            Instantiate(ShieldPrefab, 
                Quaternion.AngleAxis(360 * i / _shieldAmount, Vector3.forward) * Vector3.one * _shieldDistance,
                Quaternion.identity, transform.GetChild(0));
        }
    }
}
