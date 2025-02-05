using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _leftMouseButton = 0;
    private bool isMousePressed;

    public bool GetMousePressed => GetBoolAsTrigger(ref isMousePressed);

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            isMousePressed = true;
        }
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;

        return localValue;
    }
}
