using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomPillarWidth : CustomValue
{
    [SerializeField] 
    private float _min; 
    [SerializeField] 
    private float _max;
    [SerializeField]
    private Slider _slider;

    public override DifficutValue _valueName { get => DifficutValue.PILLAR_WIDTH; }
    public override Slider _valueSlider { get => _slider; }

    public override float _maxValue { get => _max; }
    public override float _minValue { get => _min; }
    public override float _difference { get => _max - _min; }

    public override float GetValue() => (float)Math.Round(_min + _difference * _rawValue / 100, 2);
}
