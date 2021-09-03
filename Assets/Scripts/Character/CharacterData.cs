using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : ScriptableObject
{
    [SerializeField] protected float _health, _damage, _speed;
    [SerializeField] protected CharacterType _characterType;
    [SerializeField] protected Color _color; 

    public float Health => _health;
    public float Damage => _damage;
    public float Speed => _speed;
    public CharacterType CharacterType => _characterType;
    public Color Color => _color;
}

public enum CharacterType
{
    Laborer,
    Troop
}

