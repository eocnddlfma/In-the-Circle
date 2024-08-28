using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDrop : BaseSkill
{
    public GameObject DropPrefab;
    public override IEnumerator AttackPattern()
    {
        for (int i = 0; i < _amount+ SkillManager.Instance._extraAmountAttack; i++)
        {
            Instantiate(DropPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
