using System;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamagable, IActivated
{
    protected bool _activated, _detectedObject;
    protected float _health, _damage, _speed;
    private CharacterType _characterType;
    [SerializeField]private CharacterData _characterData;

    private void Start()
    {
        _health = _characterData.Health;
        _speed = _characterData.Speed;
        _damage = _characterData.Damage;
        _characterType = _characterData.CharacterType;

        GetComponent<MeshRenderer>().material.color = _characterData.Color;
    }

    private void Update()
    {
        if(!_activated) return;
        
        Detect();
        Walk();
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    protected abstract void Detect();

    protected virtual void Attack()
    {
        //Attack State
    }

    protected virtual void Walk()
    {
        //Walk State
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    
    public void TakeDamage(float damageAmount)
    {
        _health = -damageAmount;

        if (_health <= 0)
        {
            //Die
        }
    }

    public void Activate()
    {
        _activated = true;
    }
}
