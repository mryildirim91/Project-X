using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Damage))]
public class Attack : MonoBehaviour
{
    [SerializeField] private float _attackSpeed;

    public void PerformAttack(Animator animator)
    {
        animator.speed = _attackSpeed;
        animator.SetTrigger("Attack");
    }
}
