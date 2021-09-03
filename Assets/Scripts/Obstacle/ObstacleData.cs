using UnityEngine;

[CreateAssetMenu(menuName = "Mine", fileName = "Mine")]
public class ObstacleData : ScriptableObject
{
    [SerializeField] private float _health, _reactiveDamage;
    [SerializeField] private ObstacleType obstacleType;
    [SerializeField] private Color _color; 

    public float Health => _health;
    public float ReactiveDamage => _reactiveDamage;
    public ObstacleType Type => obstacleType;
    public Color Color => _color;
}
public enum ObstacleType
{
    Stone,
    Copper,
    Iron,
    Silver,
    Diamond
}
