using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR.Haptics;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _generation;

    private Renderer _renderer;
    private Rigidbody _rigidbody;
    
    public float ScaleReduce = 2;
    public int ExplodeForce = 300;
    public int ExplodeRadius = 3;
    public float ActionChance;

    private void Awake()
    {
        _generation++;
        ExplodeForce *= 2;
        ExplodeRadius *= 2;
        ActionChance = 100 / _generation;

        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
        _rigidbody = GetComponent<Rigidbody>();
        Vector3 scale = transform.localScale;
        transform.localScale = scale / ScaleReduce;
    }
}
