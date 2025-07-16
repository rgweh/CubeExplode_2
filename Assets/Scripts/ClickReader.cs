using System;
using UnityEngine;

public class ClickReader : MonoBehaviour
{
    private int _leftMouseButton = 0;

    public event Action<Cube> CubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonUp(_leftMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.collider.TryGetComponent(out Cube cube))
                    CubeClicked(cube);
            }
        }
    }
}

