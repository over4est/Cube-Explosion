using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _speed = 2; 

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
