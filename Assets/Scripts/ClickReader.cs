using System;
using UnityEngine;

public class ClickReader : MonoBehaviour
{
    private int _leftMouseButton = 0;

    public event Action<Cube> OnCubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonUp(_leftMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Cube cube = hit.collider.GetComponent<Cube>();

                if (cube != null)
                {
                    OnCubeClicked?.Invoke(cube);
                }
            }
        }
    }
}

