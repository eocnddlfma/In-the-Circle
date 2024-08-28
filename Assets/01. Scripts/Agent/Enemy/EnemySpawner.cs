using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [FormerlySerializedAs("SpawnInfo")] public List<EnemySpawnInfoListSO> SpawnInfoListList;
    public float waitTimeAfterAllSpawned;
    public float time = 0;
    public Transform EnemyParentTransform;
    private void Start()
    {
        EnemyParentTransform = GameObject.Find("Enemys").transform;
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        foreach (EnemySpawnInfoListSO spawnInfoList in SpawnInfoListList)
        {
            foreach (EnemySpawnDataSO spawnData in spawnInfoList._list)
            {
                for (int i = 0; i < spawnData.SpawnCount; i++)
                {
                    GameObject g = Instantiate(spawnData.EnemyPrefab, EnemyParentTransform);
                    yield return new WaitForSeconds(spawnData.spawnInterval);
                }
            }
            yield return new WaitForSeconds(waitTimeAfterAllSpawned);
            GameManager.Instance.WaveUp();
        }
        
    }
}
