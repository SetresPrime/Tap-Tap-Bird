using UnityEngine;

public class SkinsManager : MonoBehaviour
{
    # region Variables
    [SerializeField] 
    private Sprite[] _skins;

    [SerializeField]
    private int[] _skinsCost;

    public static Sprite[] _skinsStatic;
    public static int[] _skinsCostStatic;

    private SpriteRenderer _birdSprite;

    private int _selectSkin;
    #endregion

    #region Initialization
    private void Awake()
    {
        _birdSprite = GetComponent<SpriteRenderer>();
        SelectSkin(PlayerPrefs.GetInt("Selected"));
        BuySelectButton._onSkinSelect += SelectSkin;

        _skinsStatic = _skins;
        _skinsCostStatic = _skinsCost;
    }
    public void SelectSkin(int skin) { _birdSprite.sprite = _skins[skin]; _selectSkin = skin; }
    #endregion

    #region Save
    private void OnDisable() => PlayerPrefs.SetInt("Selected", _selectSkin);
    
    private void OnApplicationQuit() => PlayerPrefs.SetInt("Selected", _selectSkin);
    #endregion
}


