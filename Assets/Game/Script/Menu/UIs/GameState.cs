using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour, IBaseUI
{
    public Text[] _neededCounters { get; set; }

    [SerializeField]
    private Rigidbody2D _birdRigidbody;

    private PillarSpawner _ps;

    #region IBaseUI
    private void Awake()
    {
        _ps = GetComponentInChildren<PillarSpawner>();
        _neededCounters = GetComponent<NeededCounters>()?._neededCounters;
    }
    public void ShowUI()
    {
        gameObject.SetActive(true);
        CountManager.SetCount(Count.SCORE, 0);
        _birdRigidbody.gravityScale = 1f;
        ClearScen();
        _ps.SpawnPillar();
    }
    public void HideUI()
    {
        _birdRigidbody.gravityScale = 0f;
        ClearScen();
        gameObject.SetActive(false);
    }
    public Text[] GetNeededCounters() => _neededCounters;
    public string GetContainingObjectName() => gameObject.name;
    #endregion

    void ClearScen()
    {
        Time.timeScale = 1f;
        _birdRigidbody.velocity = Vector3.zero;
        _birdRigidbody.gameObject.transform.position = Vector3.zero;
    }
}
