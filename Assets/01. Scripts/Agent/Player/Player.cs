using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Agent
{
    public static Player Instance;
    [SerializeField]private int _maxHp;
    
    protected override void Awake()
    {
        Instance = this;
        base.Awake();
        HealthCompo._maxHealth = _maxHp;
    }

    protected override void Die()
    {
        base.Die();
        SceneManager.LoadScene("GameOverScene");
        //게임오버
    }
}
