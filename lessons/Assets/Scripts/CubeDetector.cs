using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
    }

    public bool TryGetCube(out Cube cube)
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        cube = null;

        if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.transform.GetComponent<Cube>())
        {
            cube = hitInfo.transform.GetComponent<Cube>();
            return true;
        }

        return false;
    }
}
