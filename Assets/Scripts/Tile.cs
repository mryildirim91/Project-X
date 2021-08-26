using System;
using UnityEngine;

public class Tile : MonoBehaviour, IDamagable
{
    private float _health, _reactiveDamage;
    private TileType _tileType;
    [SerializeField]private TileData _tileData;

    private void Start()
    {
        _tileType = _tileData.Type;
        _health = _tileData.Health;
        _reactiveDamage = _tileData.ReactiveDamage;
        GetComponent<MeshRenderer>().material.color = _tileData.Color;
    }

    public void TakeDamage(float damageAmount)
    {
        if(_tileType == TileType.Dirt) return;

        _health -= damageAmount;
    }
}

