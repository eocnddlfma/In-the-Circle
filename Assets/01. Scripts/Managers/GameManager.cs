using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 맵에 하나밖에 없는 오브젝트들을 이름으로 먼저 찾아본 뒤 참조할 수 있는 싱글턴 클래스
 */
public class GameManager : MonoBehaviour
{
    private int wave;
    public static GameManager Instance;
    public PlayerInput _PlayerInput;
    public Transform Player, BulletParent;
    
    private void Awake()
    {
        Instance = this;
        Player = GameObject.Find("Player").transform;
        _PlayerInput = Player.GetComponent<PlayerInput>();
        BulletParent = GameObject.Find("Bullets").transform;
    }

    public void WaveUp()
    {
        wave++;
    }

}
