using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR.Haptics;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _generation;

    private float scaleReduce = 2;
    private int _explodeForce = 300;
    private int _explodeRadius = 3;
    private float _actionChance;
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;
    public int ExplodeForce => _explodeForce;
    public int ExplodeRadius => _explodeRadius;
    public float ActionChance => _actionChance;

    private void Awake()
    {
        _generation++;
        _explodeForce *= 2;
        _explodeRadius *= 2;
        _actionChance = 100 / _generation;

        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
        _rigidbody = GetComponent<Rigidbody>();
        transform.localScale = transform.localScale / scaleReduce;
    }
}
