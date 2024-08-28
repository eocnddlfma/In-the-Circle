using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Parry : MonoBehaviour
{
    [SerializeField] private float _parryRange;
    private PlayerInput PlayerInputScr;
    // Start is called before the first frame update
    private int bulletLayer;

    private void Awake()
    {
        PlayerInputScr = GetComponent<PlayerInput>();
    }

    void Start()
    {
        bulletLayer = LayerMask.NameToLayer("Bullet");
        PlayerInputScr.OnMoveInput.AddListener(TryParry);
    }
    private Collider2D[] collisions = new Collider2D[999];
    private void TryParry()
    {
         int hits =  Physics2D.OverlapCircleNonAlloc(
             transform.position, _parryRange, collisions, 1<<bulletLayer);
         //print("parry "+hits);
         if (hits > 0)
         {
             for(int i = 0; i < hits; i++)
             {
                 if (collisions[i].transform.TryGetComponent(out ParryBullet bullet))
                 {
                     if(bullet.isAttackerEnemy)
                         bullet.DoParry();
                 }
             }
         }
    }

    private void OnDestroy()
    {
        PlayerInputScr.OnMoveInput.RemoveListener(TryParry);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _parryRange);
    }

}
