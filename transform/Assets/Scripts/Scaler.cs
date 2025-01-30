using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;

    private Vector3 _scaleChange;

    private void Awake()
    {
        float scaleValue = _scaleSpeed * Time.deltaTime;
        _scaleChange = new Vector3(scaleValue, scaleValue, scaleValue);
    }

    private void Update()
    {
        transform.localScale += _scaleChange;
    }
}