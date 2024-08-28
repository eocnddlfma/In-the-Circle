using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float degree;
    public float rotationSpeed;

    [SerializeField] private bool isClockwise;
    [SerializeField] private double curDegree;
    // Start is called before the first frame update
    void Start()
    {
        isClockwise = true;
        curDegree = 0;
        //changeDirection merge Event에 등록
    }

    // Update is called once per frame
    void Update()
    {
        degree = Time.deltaTime * rotationSpeed * (isClockwise?1:-1);
        curDegree += degree;
        if (curDegree > 360 && isClockwise) isClockwise = false;
        else if (curDegree < 0 && !isClockwise) isClockwise = true;
        transform.Rotate(0,0,-degree);
        //Debug.Log(transform.rotation.eulerAngles.z);

    }

    void ChangeDirection()
    {
        isClockwise = !isClockwise;
    }
}
