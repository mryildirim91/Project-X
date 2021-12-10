using System;
using UnityEngine;

public class Laborer : Character
{
    [SerializeField] private ObstacleType _effectiveAgainst;
    protected override void Detect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, _detectionDistance,_detectionLayer))
        {
            if (_detectedObject) return;
            
            _detectedObject = true;
            
            var gotObstacle = hit.collider.gameObject.TryGetComponent(out Obstacle obstacle);
            var gotTroop = hit.collider.gameObject.TryGetComponent(out Troop troop);
            
            if (gotTroop)
                if(troop.TroopState == TroopState.Defence) return;
            
            if (gotObstacle && _effectiveAgainst != obstacle.ObstacleType || gotTroop || hit.collider.gameObject.layer == LayerMask.NameToLayer("Castle"))
            {
                _damageComponent.PassiveDamage();
                Debug.Log("passive damage");
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
