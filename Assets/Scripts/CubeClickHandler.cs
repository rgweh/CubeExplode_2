using System.Collections.Generic;
using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ClickReader _clickReader;


    private int _minChance = 0;
    private int _maxChance = 100;

    private void OnEnable()
    {
        _clickReader.CubeClicked += OnCubeClicked;
    }

    private void OnDisable()
    {
        _clickReader.CubeClicked -= OnCubeClicked;
    }

    private void OnCubeClicked(Cube cube)
    {
        if (Random.Range(_minChance, _maxChance) < cube.DuplicatingChance)
        {
            List<Cube> createdCubes = _cubeSpawner.SpawnCubes(cube);
            _exploder.Explode(createdCubes, cube);
        }
        else
        {
            _exploder.Explode(cube);
        }
        
        _cubeSpawner.DestroyCube(cube);
    }
}
