using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour , IBaseUI
{
    public Text[] _neededCounters { get; set; }

    [SerializeField]
    private Bird _bird;

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
        _bird.transform.position = new Vector3(0, 3, 0);
    }
    public Text[] GetNeededCounters() => _neededCounters;
    public string GetContainingObjectName() => gameObject.name;
    #endregion
}
