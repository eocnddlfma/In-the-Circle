using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PatternSpawnInfo")]
public class PatternSpawnInfoSO : ScriptableObject
{
    public float coolTime;
    public float initialDelay;
    public SpawnType spawnType;
    public SpawnParentType spawnParentType;
    
}
