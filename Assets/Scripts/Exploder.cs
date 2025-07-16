using System;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour 
{
    public void Explode(List<Rigidbody> explodableObjects, Cube cube)
    {
        foreach (Rigidbody obj in explodableObjects)
        {
            obj.AddExplosionForce(GetExplosionForce(cube, obj), cube.transform.position, cube.ExplodeRadius);
        }
    }

    public void Explode(List<Cube> cubes, Cube cube)
    {
        List<Rigidbody> explodableObjects = GetRigidbodies(cubes);
        Explode(explodableObjects, cube);
    }

    public void Explode(Cube cube)
    {
        Explode(GetExplodableObjects(cube), cube);
    }

    private float GetExplosionForce(Cube cube, Rigidbody obj)
    {
        float distance = Vector3.Distance(cube.transform.position, obj.transform.position);
        float forceModifier = (cube.ExplodeRadius - distance) / cube.ExplodeRadius;

        return cube.ExplodeForce * forceModifier;
    }

    private List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, cube.ExplodeRadius);

        List<Rigidbody> explodableObjects = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                explodableObjects.Add(hit.attachedRigidbody);
        }

        return explodableObjects;
    }

    private List<Rigidbody> GetRigidbodies(List<Cube> cubes)
    {
        List<Rigidbody> rigidbodies = new();

        foreach (Cube newCube in cubes)
        {
            if (newCube.TryGetComponent<Rigidbody>(out Rigidbody cubeRigidBody))
                rigidbodies.Add(cubeRigidBody);
        }

        return rigidbodies;
    }
}
