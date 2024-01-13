using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour , IBaseUI
{
    public Text[] _neededCounters { get; set; }

    #region IBaseUI
    private void Awake()
    {
        _neededCounters = GetComponent<NeededCounters>()._neededCounters;
    }
    public void HideUI()
    {
        gameObject.SetActive(false);
    }
    public void ShowUI()
    {
        gameObject.SetActive(true);
    }
    public Text[] GetNeededCounters() => _neededCounters;
    public string GetContainingObjectName() => gameObject.name;
    #endregion
}
