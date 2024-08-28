using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySpawnData")]
[Serializable]
public class EnemySpawnDataSO : ScriptableObject
{
    public GameObject EnemyPrefab;
    public int SpawnCount;
    public float spawnInterval;

    
}
