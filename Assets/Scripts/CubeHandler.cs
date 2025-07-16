using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ClickReader _clickReader;
    [SerializeField] private Cube _baseCube;
    [SerializeField] private Vector3 _spawnpoint;

    private int _minChance = 0;
    private int _maxChance = 100;

    private void OnEnable()
    {
        Cube firstCube = Instantiate(_baseCube, _spawnpoint, Quaternion.identity);
        _clickReader.CubeClicked += TrySpawnCubes;
    }

    private void OnDisable()
    {
        _clickReader.CubeClicked -= TrySpawnCubes;
    }

    private void TrySpawnCubes(Cube cube)
    {
        if (Random.Range(_minChance, _maxChance) < cube.ActionChance)
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
