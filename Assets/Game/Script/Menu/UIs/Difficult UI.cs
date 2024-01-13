using UnityEngine;
using UnityEngine.UI;

public class DifficultUI : MonoBehaviour , IBaseUI
{
    #region Variables
    public Text[] _neededCounters { get; set; }

    [SerializeField]
    private PillarSpawner _pillarManeger;
    [SerializeField]
    private Text _difficultText;

    private CustomDifficult _customDifficult;

    private Difficult _difficult;

    private Difficult _selectDifficult
    {
        get => _difficult;
        set
        {
            _difficult = value;

            if (_difficult < Difficult.EASE)
                _difficult = Difficult.CUSTOM;

            if (_difficult > Difficult.CUSTOM)
                _difficult = Difficult.EASE;
        }
    }
    #endregion

    #region IBaseUI
    public void Awake()
    {
        _neededCounters = GetComponent<NeededCounters>()?._neededCounters;
        _customDifficult = GetComponentInChildren<CustomDifficult>();

        _selectDifficult = (Difficult)PlayerPrefs.GetInt("Difficult");
    }
    public void HideUI()
    {
        if (_customDifficult && _selectDifficult == Difficult.CUSTOM)
            GetDifficult.SetCustomValues(_customDifficult.GetValues());

        GetDifficult._difficult = _selectDifficult;
        PlayerPrefs.SetInt("Difficult", (int)_selectDifficult);

        gameObject.SetActive(false);
    }
    public void ShowUI()
    {
        gameObject.SetActive(true);
        IsCustom();
        ShowDifficultText();
    }
    public Text[] GetNeededCounters() => _neededCounters;
    public string GetContainingObjectName() => gameObject.name;
    #endregion

    #region Difficult
    public void PastDifficult()
    {
        _selectDifficult--;
        IsCustom();
        ShowDifficultText();
    }
    public void NextDifficult()
    {
        _selectDifficult ++;
        IsCustom();
        ShowDifficultText();
    }
    private void IsCustom()
    {

        if (_selectDifficult == Difficult.CUSTOM)
            _customDifficult.gameObject.SetActive(true);

        else
            _customDifficult.gameObject.SetActive(false);
    }
    private void ShowDifficultText() => _difficultText.text = _selectDifficult.ToString();
    #endregion
}
