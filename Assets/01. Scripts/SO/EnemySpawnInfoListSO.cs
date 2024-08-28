using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySpawnDataList")]
[Serializable]
public class EnemySpawnInfoListSO : ScriptableObject
{
    public List<EnemySpawnDataSO> _list;
}
