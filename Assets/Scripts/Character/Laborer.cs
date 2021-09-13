using System;
using UnityEngine;

public class Laborer : Character
{
    [SerializeField] private ObstacleType _effectiveAgainst;
    protected override void Detect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5f))
        {
            if (_detectedObject) return;
            
            _detectedObject = true;

            Obstacle obstacle = hit.collider.GetComponent<Obstacle>();
            Troop troop = hit.collider.GetComponent<Troop>();

            if (obstacle == null && troop == null) return;
            if(troop.TroopState == TroopState.Attack) return;
            
            if (_effectiveAgainst != obstacle.ObstacleType || troop != null)
            {
                _damageComponent.PassiveDamage();
            }
            _movementComponent.StopWalking();
            _attackcomponent.PerformAttack(_animator);
        }
        else
        {
            if (!_detectedObject) return;
            
            _detectedObject = false;
            _movementComponent.KeepWalking();
            _damageComponent.ActiveDamage();
        }
    }
}
