using System;
using UnityEngine;
using UnityEngine.UI;
public abstract class CustomValue : MonoBehaviour
{
    public static Action _onChange;
    #region Variables
    public abstract DifficutValue _valueName { get; }
    public abstract Slider _valueSlider { get; }

    public abstract float _maxValue { get; }
    public abstract float _minValue { get; }
    public abstract float _difference {  get; }

    public Text _valueText { get; set; }
    public float _rawValue { get; set; }
    #endregion

    #region Value Methods
    public DifficutValue GetValueName() => _valueName;
    public virtual float GetValue() => (float)Math.Round(_minValue + _difference * (_rawValue / 100), 1);
    public void SetValue(float value)
    {
        _rawValue = value;
        _valueText.color = Spector.GBR(value, 200);
        _valueText.text = GetValue().ToString();

        _onChange?.Invoke();
    }
    protected void SetSettings()
    {
        _valueText = _valueSlider.gameObject.GetComponentInChildren<Text>();

        _valueSlider.value = 5;
        _valueSlider.value = PlayerPrefs.GetFloat("Custom " + _valueName.ToString());
    }
    protected void OnEnable() => SetSettings();
    protected void OnDisable() => PlayerPrefs.SetFloat("Custom " + _valueName.ToString(), _rawValue);
    #endregion
}
