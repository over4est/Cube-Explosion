using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;

    private void Update()
    {
        Vector3 scaleChange = new Vector3(_scaleSpeed, _scaleSpeed, _scaleSpeed);

        transform.localScale += scaleChange;
    }
}