using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action ValueChanged;

    private int _leftMouseButtonValue = 0;
    private Coroutine _corutine;
    private float _incrementStep = 1f;
    private float _startValue = 0f;
    private float _delay = 0.5f;
    private bool _isWorking = false;

    public float CurrentValue { get; private set; }

    private void Start()
    {
        CurrentValue = _startValue;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButtonValue))
        {
            if (!_isWorking)
            {
                _isWorking = true;
                _corutine = StartCoroutine(Countdown(_delay));
            }
            else
            {
                _isWorking = false;
                StopCoroutine(_corutine);
            }
        }
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            CurrentValue += _incrementStep;
            ValueChanged?.Invoke();

            yield return wait;
        }
    }
}
