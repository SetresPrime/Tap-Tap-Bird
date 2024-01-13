using UnityEngine;
using UnityEngine.UI;

public class LoseScreenBuilder : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Text _scoreHeaderText;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _moneyText;
    [SerializeField]
    private GameObject _HightScoreParticle;

    private int _score;
    private GameObject _hightScoreEffect;
    #endregion

    #region Lose scrine
    private void NewHightScore()
    {
        CountManager.SetCount(Count.HIGHT_SCORE, _score);
        _scoreHeaderText.text = "Hight score";
        _scoreText.text = _score.ToString();
        _hightScoreEffect = Instantiate(_HightScoreParticle, _scoreHeaderText.transform);
    }
    private void Score()
    {
        _scoreHeaderText.text = "score";
        _scoreText.text = _score.ToString();
    }
    private void Reward(bool adsIsShow) 
    { 
        int addedMoney = (int)(CountManager.GetCount(Count.SCORE) * GetDifficult.GetValue(DifficutValue.MONEY_MODIFIER)) * (adsIsShow ? 2 : 1);
        Debug.Log((int)(CountManager.GetCount(Count.SCORE) * GetDifficult.GetValue(DifficutValue.MONEY_MODIFIER)) * (adsIsShow ? 2 : 1));
        CountManager.AddToCount(Count.MONEY, addedMoney);
        _moneyText.text = addedMoney.ToString();
    }

    public void ShowLoseScrine()
    {
        _score = CountManager.GetCount(Count.SCORE);

        if (CountManager.GetCount(Count.HIGHT_SCORE) < _score)
            NewHightScore();
        else
            Score();

#if !UNITY_EDITOR
        Reward(false);
#else 
        Reward(true);
#endif
    }
    #endregion

    #region ADS
    private void AdsWasShow(IronSourcePlacement sourcePlacement, IronSourceAdInfo sourceAdInfo) => Reward(true);
    private void OnEnable()
    {
        IronSourceRewardedVideoEvents.onAdRewardedEvent += AdsWasShow;
    }
    private void OnDisable()
    {
        IronSourceRewardedVideoEvents.onAdRewardedEvent -= AdsWasShow;
        Destroy(_hightScoreEffect);
    }
    #endregion
}
