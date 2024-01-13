using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomBaseSpeed : CustomValue
{
    [SerializeField]
    private float _min;
    [SerializeField]
    private float _max;
    [SerializeField]
    private Slider _slider;

    public override DifficutValue _valueName { get => DifficutValue.BASE_SPEED; }
    public override Slider _valueSlider { get => _slider; }

    public override float _maxValue { get => _max;}
    public override float _minValue { get => _min;}
    public override float _difference { get => _max - _min; }

    public override float GetValue() => _minValue + _difference / 100 * _rawValue;
}   
