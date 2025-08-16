using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR.Haptics;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _generation;

    private int _scaleReduce = 2;
    private int _maxChance = 100;
    private Renderer _renderer;

    public int ExplodeForce { get; private set; } = 300;
    public int ExplodeRadius { get; private set; } = 4;
    public Rigidbody Rigidbody { get; private set; }
    public int DuplicatingChance { get; private set; } = 50;

    private void Awake()
    {
        _generation++;
        ExplodeForce *= _generation;
        ExplodeRadius *= _generation;
        DuplicatingChance = _maxChance / _generation;

        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
        Rigidbody = GetComponent<Rigidbody>();
        transform.localScale /= _scaleReduce;
    }
}
