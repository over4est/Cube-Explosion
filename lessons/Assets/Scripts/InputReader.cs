using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action LeftMouseButtonPressed; 

    private int _leftMouseButton = 0;
    private bool _isMousePressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            LeftMouseButtonPressed?.Invoke();
        }
    }
}
