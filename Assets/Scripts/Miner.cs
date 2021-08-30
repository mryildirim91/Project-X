using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Miner : MonoBehaviour, IDamagable, IActivated
{
    private bool _isActive;
    private float _health, _damage, _speed;
    private MinerType _minerType;
    [SerializeField] private MinerData _minerData;

    private void Start()
    {
        _health = _minerData.Health;
        _damage = _minerData.Damage;
        _speed = _minerData.Speed;
        _minerType = _minerData.Type;

        GetComponent<MeshRenderer>().material.color = _minerData.Color;
    }

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        if (_isActive)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);// NEEDS OBJECT POOLING!
    }

    public void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;
    }

    public void Activate()
    {
        _isActive = true;
    }
}
