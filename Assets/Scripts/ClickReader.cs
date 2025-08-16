using System;
using UnityEngine;

public class ClickReader : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;

    private int _leftMouseButton = 0;

    public event Action<Cube> CubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonUp(_leftMouseButton))
        {
            if (Physics.Raycast(_rayCaster.CastRayFromClick(), out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                    CubeClicked?.Invoke(cube);
            }
        }
    }
}

