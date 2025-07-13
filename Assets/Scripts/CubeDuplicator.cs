using System.Collections.Generic;
using UnityEngine;

public class CubeDuplicator : MonoBehaviour
{
    [SerializeField] private int _minAmount = 2;
    [SerializeField] private int _maxAmount = 6;
    [SerializeField] private Exploder _exploder;

    private void Awake()
    {
        _exploder.OnExploded += DestroyObject;
    }

    public List<Cube> Duplicate(Cube cube)
    {
        int amount = Random.Range(_minAmount, _maxAmount + 1);
        List<Cube> createdCubes = new List<Cube>();

        for (int i = 0; i < amount; i++)
        {
            Cube newborn = Instantiate(cube);
            createdCubes.Add(newborn);
        }

        return createdCubes;
    }

    private void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
