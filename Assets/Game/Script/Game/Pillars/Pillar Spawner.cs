using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _pillarPrefab;

    #region Variables
    private float _spawnDelay { get => GetDifficult.GetValue(DifficutValue.SPAWN_DELAY); }
    private GameObject _currentPillar;
    private GameObject _pastPillar;
    #endregion

    private void FixedUpdate()
    {
        if (_pastPillar && transform.position.x >= _pastPillar.transform.position.x + _spawnDelay)
            SpawnPillar();
    }

    public void SpawnPillar()
    {
        _currentPillar = Instantiate(_pillarPrefab, gameObject.transform);

        _currentPillar.GetComponent<Pillar>().SetSettings(_pastPillar);

        _pastPillar = _currentPillar;
    }
}
