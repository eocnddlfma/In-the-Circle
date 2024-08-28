using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    public EnemyDataSO DataSo;
    private void Start()
    {
        HealthCompo._maxHealth = DataSo.maxHp;
        transform.parent.GetComponent<EnemyMove>().rotationSpeed = DataSo.moveSpeed;
        HealthCompo.DeadEvent.AddListener(Die);
    }

    protected override void Die()
    {
        LevelManager.Instance.AddKillExp(DataSo.exp);
        print(DataSo.exp + "exp");
        Destroy(transform.parent.parent.gameObject);
    }

    private void OnDestroy()
    {
        HealthCompo.DeadEvent.RemoveListener(Die);
    }
}
