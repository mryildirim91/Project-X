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
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5f))
        {
            if (_detectedObject) return;
            _detectedObject = true;
            
            Obstacle obstacle = hit.collider.GetComponent<Obstacle>();
            Laborer laborer = hit.collider.GetComponent<Laborer>();
            
            if(hit.collider.GetComponent<Troop>().TroopState == _troopState) return;
            if(_troopState == TroopState.Attack && laborer != null) return;
            
            if (obstacle != null)
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
