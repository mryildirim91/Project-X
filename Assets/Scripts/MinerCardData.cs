using System.Collections;
using System.Collections.Generic;
using MyUtils;
using UnityEngine;

[CreateAssetMenu(menuName = "Miner Card" , fileName = "Miner Card")]
public class MinerCardData : ScriptableObject
{
    [SerializeField] private Sprite _cardSprite;
    [SerializeField] private GameObject _miner;

    public Sprite CardSprite => _cardSprite;

    public void SpawnMiner()
    {
        GameObject obj = ObjectPool.Instance.GetObject(_miner);
    }
}
