using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkillManager : MonoBehaviour
{
    [SerializeField]private BaseSkill[] Skills;
    [SerializeField]private int[] SkillLevels;
    [SerializeField] private int[] PermaUpgrade;

    private const int MAXSKILLLEVEL = 5;
    private const int MAXPERMAUPGRADELEVEL = 3;
    
    public static SkillManager Instance;
    private PlayerInput _playerInput;
    private Transform target;
    private Transform player;
    private Transform EnemyList;

    public int _damageMultiplier;
    public int _extraCooltimeReduce;
    public int _extraAmountAttack;

    
    private void Start()
    {
        SkillLevels = new int[Skills.Length];//5일거임
        for (int i = 0; i < Skills.Length; i++)
        {
            SkillLevels[i] = 0;
        }

        PermaUpgrade = new int[3];
        for (int i = 0; i < PermaUpgrade.Length; i++)
        {
            PermaUpgrade[i] = 0;
        }

        player = GameObject.Find("Player").transform;
        EnemyList = GameObject.Find("Enemys").transform;
        _playerInput = GameManager.Instance.Player.GetComponent<PlayerInput>();
    }

    private void Update()
    {
        FindTarget();
    }

    private void FindTarget()
    {
        int cnt = EnemyList.childCount;
        float distance=99999f;
        Vector3 myPos = transform.position;
        
        for (int i = 0; i < cnt; i++)
        {
            Transform t = EnemyList.GetChild(i).GetChild(0).GetChild(0);
            float dis = (t.position - myPos).magnitude;
            if (dis < distance)
            {
                target = t;
                distance = dis;
            }
        }
    }

    public Vector3 GetTargetPosition()
    {
        if (target != null)
        {
            return target.position;
        }
        else
        {
            FindTarget();
            return _playerInput.moveDirection;
        }
    }

    public List<ItemType> GetRandItemTypes()
    {
        List<ItemType> list = new List<ItemType>();
        foreach (ItemType item in Enum.GetValues(typeof(ItemType)))
        {
            switch (item)
            {
                case ItemType.Gun:
                    if (SkillLevels[0] < MAXSKILLLEVEL) list.Add(item);
                    break;
                case ItemType.Sword:
                    if (SkillLevels[1] < MAXSKILLLEVEL) list.Add(item);
                    break;
                case ItemType.Shield:
                    if (SkillLevels[2] < MAXSKILLLEVEL) list.Add(item);
                    break;
                case ItemType.Boomerang:
                    if (SkillLevels[3] < MAXSKILLLEVEL) list.Add(item);
                    break;
                case ItemType.Thunder:
                    if (SkillLevels[4] < MAXSKILLLEVEL) list.Add(item);
                    break;
                case ItemType.AttackDamage:
                    if (PermaUpgrade[0] < MAXPERMAUPGRADELEVEL) list.Add(item);
                    break;
                case ItemType.AttackCoolTime:
                    if (PermaUpgrade[1] < MAXPERMAUPGRADELEVEL) list.Add(item);
                    break;
                case ItemType.AttackAmount:
                    if (PermaUpgrade[2] < MAXPERMAUPGRADELEVEL) list.Add(item);
                    break;
            }
        }

        while (list.Count > 3)
        {
            int n = Random.Range(0, list.Count);
            list.RemoveAt(n);
        }

        for (int i = 0; i < 5; i++)
        {
            int n = Random.Range(0, list.Count);
            var a = list[n];
            list.RemoveAt(n);
            list.Add(a);
        }
        return list;
    }

    public void UpgradeSkill(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Gun:
                Skills[0].Upgrade();
                SkillLevels[0]++;
                break;
            case ItemType.Sword:
                Skills[1].Upgrade();
                SkillLevels[1]++;
                break;
            case ItemType.Shield:
                Skills[2].Upgrade();
                SkillLevels[2]++;
                break;
            case ItemType.Boomerang:
                Skills[3].Upgrade();
                SkillLevels[3]++;
                break;
            case ItemType.Thunder:
                Skills[4].Upgrade();
                SkillLevels[4]++;
                break;
            case ItemType.AttackDamage:
                if (PermaUpgrade[0] == 0)
                {
                    _damageMultiplier = 2;
                }if (PermaUpgrade[0] == 1)
                {
                    _extraAmountAttack = 3;
                    
                }if (PermaUpgrade[0] == 2)
                {
                    _extraAmountAttack = 5;
                }
                PermaUpgrade[0]++;
                break;
            case ItemType.AttackCoolTime:
                if (PermaUpgrade[1] == 0)
                {
                    _extraCooltimeReduce = 10;
                }if (PermaUpgrade[1] == 1)
                {
                    _extraCooltimeReduce = 30;
                }if (PermaUpgrade[1] == 2)
                {
                    _extraCooltimeReduce = 50;
                }
                PermaUpgrade[1]++;
                break;
            case ItemType.AttackAmount:
                if (PermaUpgrade[2] == 0)
                {
                    _extraAmountAttack = 1;
                }if (PermaUpgrade[2] == 1)
                {
                    _extraAmountAttack = 2;
                }if (PermaUpgrade[2] == 2)
                {
                    _extraAmountAttack = 4;
                }
                PermaUpgrade[2]++;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
        }
    }
}
