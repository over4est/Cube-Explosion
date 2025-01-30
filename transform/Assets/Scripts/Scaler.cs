using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;

    private void Update()
    {
        Vector3 scaleChange = Vector3.one * _scaleSpeed * Time.deltaTime;
        transform.localScale += scaleChange;
    }
}