using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Health),typeof(Movement),typeof(Damage))]
public abstract class Character : MonoBehaviour, IActivated
{
    private bool _active;
    protected bool _detectedObject;
    protected Health _healthComponent;
    protected Movement _movementComponent;
    protected Damage _damageComponent;
    protected Attack _attackcomponent;
    protected Animator _animator;
    [SerializeField] private Color _color; //temporary
    [SerializeField]private CharacterType _characterType;

    protected abstract void Detect();
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _healthComponent = GetComponent<Health>();
        _movementComponent = GetComponent<Movement>();
        _damageComponent = GetComponent<Damage>();
        _attackcomponent = GetComponent<Attack>();
        GetComponent<MeshRenderer>().material.color = _color;
    }

    protected virtual void OnEnable()
    {
        _active = false;
        _healthComponent.enabled = false;
        _movementComponent.enabled = false;
        _damageComponent.enabled = false;
        _attackcomponent.enabled = false;
    }

    private void Update()
    {
        if(!_active) return;
        
        Detect();
    }

    private void OnBecameInvisible()
    {
        ObjectPool.Instance.ReturnGameObject(gameObject);
    }
    public void Activate()
    {
        _active = true;
        _healthComponent.enabled = true;
        _movementComponent.enabled = true;
        _damageComponent.enabled = true;
        _attackcomponent.enabled = true;
    }
}

public enum CharacterType
{
    Laborer,
    Troop
}
