using UnityEngine;

public class Miner : MonoBehaviour, IDamagable
{
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

    public void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;
    }
}
