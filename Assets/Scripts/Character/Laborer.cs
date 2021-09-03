using System;
using UnityEngine;

public class Laborer : Character
{
    [SerializeField]private LaborerData _laborerData;
    
    protected override void Detect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5f))
        {
            if (_detectedObject) return;
            
            _detectedObject = true;

            /*var mine = hit.collider.GetComponent<Obstacle>();

            if (_laborerData.EffectiveAgainst != mine.ObstacleType)
                _damage = _laborerData.IneffectiveDamage;*/

            //Attack State
            Attack();
        }
        else
        {
            if (!_detectedObject) return;
            
            _detectedObject = false;
            
        }
    }
}
