using UnityEngine;

[CreateAssetMenu(menuName = "Tile", fileName = "Tile")]
public class TileData : ScriptableObject
{
    [SerializeField] private float _health, _reactiveDamage;
    [SerializeField] private TileType _tileType;
    [SerializeField] private Color _color; 

    public float Health => _health;
    public float ReactiveDamage => _reactiveDamage;
    public TileType Type => _tileType;
    public Color Color => _color;
}
public enum TileType
{
    Dirt,
    Wood,
    Stone,
    Iron
}
