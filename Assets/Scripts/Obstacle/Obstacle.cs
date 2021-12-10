using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Color _color; //temporary
    [SerializeField]private ObstacleType _obstacleType;
    public ObstacleType ObstacleType => _obstacleType;
    
    private Health _healthComponent;
    private Damage _damageComponent;

    private void Awake()
    {
        _healthComponent = GetComponent<Health>();
        _damageComponent = GetComponent<Damage>();
        GetComponent<MeshRenderer>().material.color = _color;//temporary
    }

    private void OnEnable()
    {
        _damageComponent.PassiveDamage();
    }
}

public enum ObstacleType
{
    Wood,
    Stone,
    Copper,
    Iron,
    Silver,
    Diamond
}

