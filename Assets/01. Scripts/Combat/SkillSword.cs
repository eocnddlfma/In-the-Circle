using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSword : BaseSkill
{
    public Transform XAxisParent;
    public Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        XAxisParent = transform.parent;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public override void StartAttack()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        base.StartAttack();
    }

    public override IEnumerator AttackPattern()
    {
        Vector3 pos = SkillManager.Instance.GetTargetPosition();
        if (pos.x >= transform.position.x)
        {
            XAxisParent.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            XAxisParent.localScale = new Vector3(-1, 1, 1);
        }
        
        for (int i = 0; i < _amount+ SkillManager.Instance._extraAmountAttack; i++)
        {
            DoAttack();
            yield return new WaitForSeconds(0.1f);
        }
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
                _modifiedCooltime = _cooltime / 7;
                break;
            case 2:
                _modifiedDamage = _damage;
                break;
            case 3:
                _modifiedCooltime = _cooltime / 3;
                _animator.speed = 1.5f;
                break;
            case 4:
                _modifiedCooltime = _cooltime / 2;
                _modifiedDamage = _damage * 3;
                _animator.speed = 2f;
                break;
        }
        _level++;
    }
    
    private void DoAttack()
    {
        _animator.SetTrigger("Attack");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Agent agent))
        {
            agent.GetComponent<Agent>().HealthCompo.Damage(GetDamage());
        }
    }
}
