using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BulletInfo")]
public class BulletInfoSO : ScriptableObject
{
    public int damage;
    public bool destroyWhenHit;
    public float duration;
    public BulletType BulletType;
    public bool isOverrideChildDamage;

    public float moveSpeed;
    public float rotationSpeed;
}
