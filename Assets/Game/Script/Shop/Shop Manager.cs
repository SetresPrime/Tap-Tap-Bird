using UnityEngine;

public class ShopManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private BuySelectButton _buttonPrefab;

    private float _spacing;
    private float _buttonSize;

    private Vector2 _shopBackgroundSize;
    private Vector2 _buttonsFieldSize;
    #endregion

    #region Start
    private void Awake()
    {
        _shopBackgroundSize = GetComponent<RectTransform>().sizeDelta;
        _buttonSize = _buttonPrefab.GetComponent<RectTransform>().sizeDelta.x * 0.65f;
    }
    private void Start()
    {
        CalculatedFieldParameters();
        CreatButtonsFild();
    }
    #endregion

    #region Field
    public void CreatButtonsFild()
    {
        int x = 0, y = 0, i = 0;
        
        foreach (var skin in SkinsManager._skinsStatic)
        {
            CreatButton(x, y).SetButtonParameters(i);
            if (y != _buttonsFieldSize.y - 1)
            { y++; i++; }
            else
            { x++; y = 0; }        
        }
    }
    public BuySelectButton CreatButton(int y, int x)
    {
        var button = Instantiate(_buttonPrefab, transform, false);
        button.transform.localPosition = Position(x, y);
        return button;
    }
    public Vector2 Position(int x, int y)
    {
        float startX = -(_shopBackgroundSize.x / 2) + (_buttonSize / 2) + _spacing;
        float startY = (_shopBackgroundSize.y / 2) - (_buttonSize / 2) - _spacing;

        var position = new Vector2(startX + (x * (_buttonSize + _spacing)), startY - (y * (_buttonSize + _spacing)));
        return position;
    }
    private void CalculatedFieldParameters()
    {
        _buttonsFieldSize.x = (int)(_shopBackgroundSize.x / _buttonSize);
        _buttonsFieldSize.y = (int)(_shopBackgroundSize.y / _buttonSize);

        _spacing = _shopBackgroundSize.x % _buttonSize / (_buttonsFieldSize.x + 1);
    }
    #endregion
}
