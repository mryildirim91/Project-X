using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private float _damage;
    [SerializeField] private float _activeDamage, _passiveDamage;
    
    public void PassiveDamage()
    {
        _damage = _passiveDamage;
    }

    public void ActiveDamage()
    {
        _damage = _activeDamage;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        
        damagable?.TakeDamage(_damage);
    }
}
