using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _healthAmount;

    public float HealthAmount => _healthAmount;
    
    public void TakeDamage(float damageAmount)
    {
        _healthAmount -= damageAmount;
    }
}
