using System;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    private float _health, _reactiveDamage;
    private ObstacleType _obstacleType;
    public ObstacleType ObstacleType => _obstacleType;
    [SerializeField]private ObstacleData obstacleData;

    private void Start()
    {
        _obstacleType = obstacleData.Type;
        _health = obstacleData.Health;
        _reactiveDamage = obstacleData.ReactiveDamage;
        GetComponent<MeshRenderer>().material.color = obstacleData.Color;
    }

    public void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;

        if (_health <= 0)
        {
            //
        }
    }
}

