using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour, IBaseUI
{
    public Text[] _neededCounters { get; set; }

    private LoseScreenBuilder _lSB;

    #region IBaseUI
    private void Awake()
    {
        _lSB = GetComponent<LoseScreenBuilder>();
    }
    public void HideUI()
    {
        gameObject.SetActive(false);
    }
    public void ShowUI()
    {
        gameObject.SetActive(true);
        _lSB.ShowLoseScrine();
    }
    public Text[] GetNeededCounters() => _neededCounters;
    public string GetContainingObjectName() => gameObject.name;
    #endregion
}
