using UnityEngine.UI;

public interface IBaseUI
{
    Text[] _neededCounters { get; set; }
    void HideUI();
    void ShowUI();
    Text[] GetNeededCounters();
    string GetContainingObjectName();
}
