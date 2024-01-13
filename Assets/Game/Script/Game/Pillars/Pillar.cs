using UnityEngine;

public class Pillar : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject[] _pillars;

    private Collider2D _pointZone;
    private GameObject _pastPillar;
    private Rigidbody2D _rb;

    public float _distanceBetween { get => GetDifficult.GetValue(DifficutValue.DISTANCE_BETWEEN);}
    public float _pillarWidth { get => GetDifficult.GetValue(DifficutValue.PILLAR_WIDTH); }
    public float _spawnOffset { get => GetDifficult.GetValue(DifficutValue.SPAWN_OFFSET); }
    public float _baseSpeed { get => GetDifficult.GetValue(DifficutValue.BASE_SPEED); }
    public float _speedMultiplier { get => GetDifficult.GetValue(DifficutValue.SPEED_MULTIPLIER); }
    public int _speedBreakPoint { get => (int)GetDifficult.GetValue(DifficutValue.SPEED_BREAK_POINT); }
    #endregion

    #region Pillar Transform
    public void SetSettings( GameObject pastPillar) 
    {
        Bird.onAddPoint += AddSpeed;
        _rb = GetComponent<Rigidbody2D>();
        _pastPillar = pastPillar;
        _pointZone = GetComponent<Collider2D>();

        TransformPillar();
        AddSpeed();
    }
    private void TransformPillar()
    {
        _pillars[0].transform.localPosition = new Vector3(0, (_distanceBetween + 5.5f) / 2, 0);
        _pillars[1].transform.localPosition = new Vector3(0, -(_distanceBetween + 5.5f) / 2, 0);

        foreach (var pillar in _pillars)
            pillar.transform.localScale = new Vector3(_pillarWidth, 3, 1);

        OffsetPillar();
    }
    private void OffsetPillar()
    {
        if (_pastPillar == null)
            return;

        var pillarOffset = _pastPillar.transform.position.y - Random.Range(-_spawnOffset, _spawnOffset);
        var maxPillarOffset = _distanceBetween / 2 - 5;

        pillarOffset = pillarOffset < maxPillarOffset  ? maxPillarOffset : pillarOffset;
        pillarOffset = pillarOffset > -maxPillarOffset ? -maxPillarOffset : pillarOffset;
        transform.position = new Vector3(0, pillarOffset, 0) + transform.position;
    }
    private void AddSpeed()
    {

        _rb.velocity = Vector3.zero;

        float breakPoinFactor = _speedBreakPoint / Mathf.Pow(_speedBreakPoint, _speedMultiplier);
        Debug.Log($"breakPoinFactor : {breakPoinFactor} \n" +
                  $"speedBreakPoint : {_speedBreakPoint} \n" +
                  $"speedMultiplier : {_speedMultiplier} \n");
        float spawnSpeed = Mathf.Pow(CountManager.GetCount(Count.SCORE), _speedMultiplier) * breakPoinFactor + _baseSpeed;
        _rb.AddForce(new Vector2(spawnSpeed > 500 ? -500 : -spawnSpeed, 0), ForceMode2D.Force);

        Debug.Log($"Pillar get speed : {spawnSpeed}");

    }
    private void DestroyPillar()
    {
        Bird.onAddPoint -= AddSpeed;
        Destroy(gameObject);
    }
    #endregion

    #region Base
    private void Update()
    {
        if(transform.position.x <= -5f)
            DestroyPillar();
    }
    private void OnDisable() => DestroyPillar();
    #endregion 
}
