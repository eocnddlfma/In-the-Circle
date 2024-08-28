using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyData")]
[Serializable]
public class EnemyDataSO : ScriptableObject
{
    public float moveSpeed;
    public int maxHp;
    public int exp;
}
