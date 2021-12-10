using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Troop : Character
{
    private TroopState _troopState;
    public TroopState TroopState => _troopState;
    
    protected override void Detect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, _detectionDistance,_detectionLayer))
        {
            if (_detectedObject) return;
            _detectedObject = true;
            
            var gotObstacle = hit.collider.gameObject.TryGetComponent(out Obstacle obstacle);
            var gotLaborer = hit.collider.gameObject.TryGetComponent(out Laborer laborer);
            var gotTroop = hit.collider.gameObject.TryGetComponent(out Troop troop);
            
            if(gotTroop)
                if(_troopState == troop.TroopState) return; // don't attack other troop if same state
            
            if(_troopState == TroopState.Attack && gotLaborer) return; // don't attack laborer if troop is in attack state
            
            if (gotObstacle)
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

public enum TroopState
{
    Attack,
    Defence
}
