using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomDifficult : MonoBehaviour
{
    [SerializeField]
    private Text _moneyModifierText;

    private CustomValue[] _customValues;
    private float _distanceBetween { get => _customValues[0]._rawValue; }
    private float _pillarWidth     { get => _customValues[1]._rawValue; }
    private float _spawnOffset     { get => _customValues[2]._rawValue; }
    private float _spawnDelay      { get => _customValues[3]._rawValue; }
    private float _baseSpeed       { get => _customValues[4]._rawValue; }
    private float _speedMultiplier { get => _customValues[5]._rawValue; }
    private float _speedBreakPoint { get => _customValues[6]._rawValue; }
    private float _moneyModifier;


    private void Awake()
    {
        _customValues = GetComponents<CustomValue>();
    }
    private void UpdateMoneyModifier()
    {
        //float speedModifier = _speedMultiplier != 0 ? (float)(1 / (1 / (Math.Pow(_speedBreakPoint, _speedMultiplier) * Math.Pow(10, _speedMultiplier))) / 10) : 0;
        //float pillarModifier = (float);
        //_moneyModifier = (float)Math.Round((speedModifier + (2 * _distanceBetween * _pillarWidth * _spawnDelay)) * 2 * _spawnOffset, 1);

        //_moneyModifierText.text = "X" + _moneyModifier;
        _moneyModifier = 0;
    }
    public float[] GetValues()
    {
        float[] values = new float[8];

        foreach (CustomValue customValue in _customValues)
            values[(int)customValue.GetValueName()] = customValue.GetValue();
        values[(int)DifficutValue.MONEY_MODIFIER] = _moneyModifier;
        values[(int)DifficutValue.SPEED_BREAK_POINT] = 5;
        return values;
    }
    private void OnEnable()
    {
        CustomValue._onChange += UpdateMoneyModifier;
    }

    private void OnDisable()
    {
        CustomValue._onChange -= UpdateMoneyModifier;
    }
}
