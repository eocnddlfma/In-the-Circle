using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullet은 자기 자식으로 SpinTarget을 갖고 그 자식으로 bullet들을 가짐.
public  class BaseBullet : MonoBehaviour
{
    public BulletInfoSO bulletInfoSo;

    public float moveSpeed;
    public float spinSpeed;
    public int damage;
    public bool destroyWhenHit;
    public float duration;
    public bool isOverrideChildDamage;
    public BulletType BulletType;
    public bool isAttackerEnemy;
    
    public Transform MovingTransform;//이동시킬 트렌스폼
    public Transform TargetTransform;//목적지 트렌스폼
    public Transform ParentTransform;//나를 생성시킨 트렌스폼
    public Transform SpinTransform;//회전할시 사용할 트렌스폼

    public bool isAttackable;
    private void Awake()
    {
        Setting();
    }

    public virtual void Setting()
    {
        moveSpeed = bulletInfoSo.moveSpeed;
        spinSpeed = bulletInfoSo.rotationSpeed;
        isOverrideChildDamage = bulletInfoSo.isOverrideChildDamage;
        damage = bulletInfoSo.damage;
        destroyWhenHit = bulletInfoSo.destroyWhenHit;
        duration = bulletInfoSo.duration;
        BulletType = bulletInfoSo.BulletType;
    }
    protected virtual void Start()
    {
        TargetTransform = GameManager.Instance.Player;
        MovingTransform = transform;
        if (transform.childCount > 0) SpinTransform = transform.GetChild(0);
        CheckOverrideChildDamage();
        StartCoroutine(DoPattern());
    }
    
    private void CheckOverrideChildDamage()
    {
        if (bulletInfoSo.isOverrideChildDamage)
        {
            if(transform.GetChild(0).childCount>0)
                for (int i=0; i<transform.GetChild(0).childCount;i++)
                {
                    BaseBullet bb =transform.GetChild(0).GetChild(i).GetComponent<BaseBullet>();
                    bb.isOverrideChildDamage = true;
                    bb.damage = damage;
                }
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (isAttackerEnemy && other.gameObject.CompareTag("Enemy")) isAttackable=false;
        else if (!isAttackerEnemy && other.CompareTag("Player")) isAttackable=false;
        else if (other.CompareTag("Shield")) Destroy(gameObject);
        else if (other.gameObject.name == "Out")
        {
            isAttackable = false;
            Destroy(gameObject);
        }
        else
        {
            isAttackable = true;
        }
    }

    public float time = 0;
    private IEnumerator DoPattern()
    {
        PatternSetting();
        while (time<=duration)
        {
            Pattern();
            yield return null;
            time += Time.deltaTime;
        }
        Destroy(MovingTransform.gameObject);
    }

    public virtual void PatternSetting()
    {
        
    }
    public virtual void Pattern()
    {
        
    }

    public void DoDamage(Collider2D other)
    {
        print(other);
        if(other.TryGetComponent(out Agent agent)) agent.HealthCompo.Damage(damage);
    }
}
