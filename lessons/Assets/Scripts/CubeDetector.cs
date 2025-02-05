using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    private Vector3 _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>().transform.position;
    }

    public bool TryGetCube(out Cube cube)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        cube = null;

        if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.transform.GetComponent<Cube>())
        {
            cube = hitInfo.rigidbody.GetComponent<Cube>();
            return true;
        }

        return false;
    }
}
