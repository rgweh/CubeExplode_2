using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _generation;
    [SerializeField] private int _explodeForce = 300;
    [SerializeField] private int _explodeRadius = 3;
    [SerializeField] private float _actionChance;
    private float _scaleReduce = 2;

    public int ExplodeForce => _explodeForce;
    public int ExplodeRadius => _explodeRadius;
    public float ActionChance => _actionChance;

    private void Awake()
    {
        _generation++;

        _actionChance = 100 / _generation;

        Vector3 scale = transform.localScale;
        transform.localScale = scale / _scaleReduce;

        if (TryGetComponent(out Renderer renderer))
            renderer.material.color = Random.ColorHSV();

        _explodeForce *= 2;
        _explodeRadius *= 2;
    }
}
