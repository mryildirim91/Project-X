using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _initialSpeed;
    [SerializeField] private float _speed;
    public float Speed => _speed;

    private void OnEnable()
    {
        _initialSpeed = _speed;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void StopWalking()
    {
        _speed = 0;
    }

    public void KeepWalking()
    {
        _speed = _initialSpeed;
    }
}