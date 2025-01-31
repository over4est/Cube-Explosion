using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private float _currentValue;
    private float _increaseStep = 1f;
    private float _startValue = 0f;
    private float _delay = 0.5f;
    private bool _isWorking = false;

    private void Start()
    {
        _text.text = _startValue.ToString();
        _currentValue = _startValue;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isWorking)
            {
                _isWorking = false;
                StopCoroutine(Countdown(_delay));
            }
            else
            {
                _isWorking = true;
                StartCoroutine(Countdown(_delay));
            }
        }
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isWorking)
        {
            DisplayValue(_currentValue);

            _currentValue += _increaseStep;

            yield return wait;
        }
    }

    private void DisplayValue(float value)
    {
        _text.text = value.ToString();
    }
}
