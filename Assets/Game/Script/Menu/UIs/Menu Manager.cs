using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private IBaseUI[] _UIs;
    private CountManager _countManager;
    void Start()
    {
        _UIs = GetComponentsInChildren<IBaseUI>();
        
        _countManager = GetComponentInChildren<CountManager>();
        ShowInterface("Main Menu");
    }
    public void ShowInterface(string interfaceName)
    {
        HideAllInterfaceExcept(interfaceName);
    }
    void HideAllInterfaceExcept(string exception)
    {
        foreach (var UI in _UIs)
        {
            if (UI.GetContainingObjectName() != exception)
                UI.HideUI();
            else
            {
                UI.ShowUI();
                _countManager.HideOtherCounts(UI.GetNeededCounters());
            }          
        }
    }
}
