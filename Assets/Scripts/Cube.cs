using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR.Haptics;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _generation;
    [SerializeField] private int _initialExplodeForce = 300;
    [SerializeField] private int _initialExplodeRadius = 4;

    private float scaleReduce = 2;
    private int _maxChance = 100;
    private Renderer _renderer;

    public Rigidbody Rigidbody { get; private set; }
    public float ActionChance { get; private set; }
    public int ExplodeForce { get; private set; }
    public int ExplodeRadius { get; private set; }

    private void Awake()
    {
        _generation++;
        ExplodeForce = _initialExplodeForce * _generation;
        ExplodeRadius = _initialExplodeRadius * _generation;
        ActionChance = _maxChance / _generation;

        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
        Rigidbody = GetComponent<Rigidbody>();
        transform.localScale = transform.localScale / scaleReduce;
        Debug.Log("radius = " + ExplodeRadius);
    }
}
