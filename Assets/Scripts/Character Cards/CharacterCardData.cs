using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterCardData : ScriptableObject
{
    [SerializeField] private Sprite _cardSprite;
    [SerializeField] private GameObject _prefab;
    public Sprite CardSprite => _cardSprite;

    public GameObject SpawnMiner()
    {
        return Instantiate(_prefab);// NEEDS OBJECT POOLING!
    }
}
