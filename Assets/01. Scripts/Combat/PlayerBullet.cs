using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float moveSpeed;
    private float damage;
    
    public Transform MovingTransform;//이동시킬 트렌스폼
    public Transform TargetTransform;//목적지 트렌스폼
    public SkillShoot sh;//목적지 트렌스폼

    [SerializeField]private Vector3 _direction;
    
    protected virtual void Start()
    {
        sh = GameManager.Instance.Player.Find("Skills").GetComponentInChildren<SkillShoot>();
        _direction = sh._direction;
        MovingTransform = transform;
        damage = sh._damage;
        moveSpeed = sh._moveSpeed;
        StartCoroutine(DoPattern());
    }
    
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DoDamage(other);
        }
    }

    private IEnumerator DoPattern()
    {
        while (true)
        {
            Pattern();
            yield return null;
        }
    }

    public virtual void Pattern()
    {
        
        MovingTransform.Translate(_direction * (moveSpeed * Time.deltaTime));
    }

    public void DoDamage(Collider2D other)
    {
        other.GetComponent<Agent>().HealthCompo.Damage(sh.GetDamage());
    }
}
