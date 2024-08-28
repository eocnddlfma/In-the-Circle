using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotationAndPosition : MonoBehaviour
{
    [SerializeField]private Vector3 rotation;
    [SerializeField]private Vector3 position;

    public bool SetPosition;
    public bool SetRotation;
    
    private Quaternion rot;
    private void Start()
    {
        rot = Quaternion.Euler(rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(SetRotation)
        transform.rotation = rot;
        if(SetPosition)
        transform.position = transform.parent.position + position;
    }
}
