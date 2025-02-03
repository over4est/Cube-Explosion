using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _timer.ValueChanged += DisplayValue;
        _text.text = "0";
    }

    private void OnDisable()
    {
        _timer.ValueChanged -= DisplayValue;
    }

    private void DisplayValue()
    {
        _text.text = _timer.CurrentValue.ToString();
    }
}
