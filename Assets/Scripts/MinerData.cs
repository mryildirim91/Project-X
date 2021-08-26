using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Miner", fileName = "Miner")]
public class MinerData : ScriptableObject
{
    [SerializeField] private float _health, _damage, _speed;
    [SerializeField] private MinerType _minerType;
    [SerializeField] private Color _color; 

    public float Health => _health;
    public float Damage => _damage;
    public float Speed => _speed;
    public MinerType Type => _minerType;
    public Color Color => _color;
}

public enum MinerType
{
    Miner1,
    Miner2,
    Miner3,
    Miner4
}
