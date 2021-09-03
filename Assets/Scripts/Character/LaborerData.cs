using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Laborer", fileName = "Laborer")]
public class LaborerData : CharacterData
{
    [SerializeField] private float _ineffectiveDamage;
    [SerializeField] private ObstacleType _effectiveAgainst;

    public float IneffectiveDamage => _ineffectiveDamage;
    public ObstacleType EffectiveAgainst => _effectiveAgainst;
}
