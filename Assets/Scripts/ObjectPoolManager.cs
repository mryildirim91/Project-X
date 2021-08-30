
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] private PoolData[] _objects;
}

[System.Serializable]
public struct PoolData
{
    [SerializeField] private int _numberOfObject;
    [SerializeField] private GameObject _prefab;
}
