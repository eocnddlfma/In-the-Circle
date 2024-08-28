using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnAttack : MonoBehaviour
{
    [SerializeField]private GameObject BulletPrefab;
    [SerializeField] private PatternSpawnInfoSO _spawnInfo;

    [FormerlySerializedAs("isEnemyAttack")] public bool isAttackerEnemy;
    private float _currentTime;
    private float _spawnCoolTime;
    private float _initialDelay;
    private SpawnType _spawnType;
    private SpawnParentType _spawnParentType;

    private void Awake()
    {
        Setting();
    }

    private void Setting()
    {
        _currentTime = _spawnType == SpawnType.Continuous?0f:_spawnInfo.coolTime;
        _spawnCoolTime = _spawnInfo.coolTime;
        _initialDelay = _spawnInfo.initialDelay;
        _spawnType = _spawnInfo.spawnType;
        _spawnParentType = _spawnInfo.spawnParentType;
    }

    private void Start()
    {
        StartCoroutine(DoSpawning());
    }

    private IEnumerator DoSpawning()
    {
        yield return new WaitForSeconds(_initialDelay);
        do
        {
            if (_currentTime >= _spawnCoolTime)
            {
                SpawnBullet();
                _currentTime -= _spawnCoolTime;
            }
            
            yield return null;
            _currentTime += Time.deltaTime;

        } while (_spawnType == SpawnType.Continuous);
    }

    private void SpawnBullet()
    {
        BaseBullet b;
        if (_spawnParentType == SpawnParentType.WorldPosition)
        {
            b = Instantiate(BulletPrefab, transform.position, Quaternion.identity, GameManager.Instance.BulletParent).GetComponent<BaseBullet>();
        }
        else
        {
            b = Instantiate(BulletPrefab, transform).GetComponent<BaseBullet>();
        }
        b.ParentTransform = transform;
        b.isAttackerEnemy = isAttackerEnemy;
    }
}
