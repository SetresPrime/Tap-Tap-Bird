using System;
using UnityEngine;
using UnityEngine.UI;

public class BuySelectButton : MonoBehaviour
{
    #region Variables
    public static Action<int> _onSkinSelect;

    [SerializeField]
    private Image _sellingSkinImage;

    [SerializeField]
    private Text _sellingCostText;

    private bool _isBought;
    private int _cost;
    private int _skinNum;
    #endregion

    #region Initialization
    public void SetButtonParameters(int skinNum)
    {
        _sellingSkinImage.sprite = SkinsManager._skinsStatic[skinNum];
        _cost = SkinsManager._skinsCostStatic[skinNum];
        _skinNum = skinNum;
        _sellingCostText.text = _cost.ToString();

        if(PlayerPrefs.GetInt(_skinNum.ToString()) == 1 || _cost == 0)
        {
            SwithToSelectable();
        }
    }
    #endregion

    #region Buy or select
    public void BuyOrSelect()
    {
        if (_isBought)
            Select();  
        else 
            Buy();
    }
    private void Select() 
    { 
        if (Input.GetKey(KeyCode.C))
            PlayerPrefs.SetInt(_skinNum.ToString(), 0);

        else _onSkinSelect?.Invoke(_skinNum);
    }
    private void Buy()
    {
        if (CountManager.GetCount(Count.MONEY) >= _cost)
        {
            CountManager.AddToCount(Count.MONEY, -_cost);
            SwithToSelectable();
        }
    }
    private void SwithToSelectable()
    {
        _sellingSkinImage.transform.localPosition = Vector3.zero;
        Destroy(_sellingCostText.gameObject);

        _isBought = true;

        PlayerPrefs.SetInt(_skinNum.ToString(), 1);
    }
    #endregion
}
