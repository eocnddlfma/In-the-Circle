using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public UnityEvent DeadEvent;
    public float _maxHealth;
    [SerializeField]private float _currentHealth;
    
    [SerializeField]private Image _currentHealthImage;
    [SerializeField]private GameObject _HealthObject;

    private void Start()
    {
        _HealthObject = transform.GetChild(0).gameObject;
        _currentHealthImage = _HealthObject.transform.GetChild(0).Find("CurrentHealthUI").GetComponent<Image>();
        _currentHealth = _maxHealth;
    }

    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            _currentHealthImage.fillAmount = _currentHealth /(float)_maxHealth;
            //print(_currentHealth);
            if (value <= 0)
            {
                DeadEvent.Invoke();
            }
        }
    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
    }
    
    private void Update()
    {
        //_HealthObject.transform.rotation = Quaternion.identity;
    }
}
