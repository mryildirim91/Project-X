using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : Character
{
    protected override void Detect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5f))
        {
            if (_detectedObject) return;
            
            _detectedObject = true;

            if (hit.collider.CompareTag("Castle"))
            {
                //Attack State
                Attack();
            }
            else
            {
                //Die
            }
        }
        else
        {
            if (!_detectedObject) return;
            
            _detectedObject = false;
            
        }
    }
}
