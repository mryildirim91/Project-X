using System.Collections;
using System.Collections.Generic;
using MyUtils;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _gridWidth, _gridHeight;
    [SerializeField]private GameObject[] _tiles;
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < _gridWidth; x++)
        {
            for (int z = 0; z < _gridHeight; z++)
            {
                int randomGrid = Random.Range(0, _tiles.Length);
                GameObject obj = ObjectPool.Instance.GetObject(_tiles[randomGrid]);
                obj.transform.position = GetPosition(x, z, (float)(_gridWidth - 1) / 2, (float)(_gridHeight - 1) / 2);
                obj.transform.parent = transform;
            }
        }  
    }
    private Vector3 GetPosition(int x, int z, float xOffset, float zOffset)
    {
        return new Vector3(x - xOffset, 0, z - zOffset);
    }
}
