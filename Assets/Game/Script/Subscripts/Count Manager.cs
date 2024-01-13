using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CountManager : MonoBehaviour
{
    private static int[] _counts = new int[3];
    private List<Text> _textPanels = new List<Text>();

    #region Base
    private void OnEnable()
    {
        foreach (Text textPanel in GetComponentsInChildren<Text>())
            if (textPanel.name.ToLower().Split(" ")[0] != "text")
                _textPanels.Add(textPanel);

        foreach (Count count in Enum.GetValues(typeof(Count)))
            _counts[(int)count] = PlayerPrefs.GetInt(count.ToString());
       
    }
    private void Update()
    {
        foreach (Count count in Enum.GetValues(typeof(Count)))
        {
            _textPanels[(int)count].text = _counts[(int)count].ToString();
        }

        if (Input.GetKey(KeyCode.W))
            _counts[(int)Count.MONEY] += 1000;
        else if (Input.GetKey(KeyCode.S))
            _counts[(int)Count.MONEY] -= 1000;

        if (Input.GetKey(KeyCode.D))
            _counts[(int)Count.HIGHT_SCORE] += 1;
        else if (Input.GetKey(KeyCode.A))
            _counts[(int)Count.HIGHT_SCORE] -= 1;
    }
    private void OnApplicationQuit()
    {
        foreach (Count count in Enum.GetValues(typeof(Count)))
            if (count != Count.SCORE)
                PlayerPrefs.SetInt(count.ToString(), _counts[(int)count]);
    }
    #endregion

    #region Count
    public static int GetCount(Count count) => _counts[(int)count];
    public static void SetCount(Count count, int value) => _counts[(int)count] = value;
    public static void AddToCount(Count count, int value) => _counts[(int)count] += value;
    #endregion

    #region Hide
    public void HideOtherCounts(Text[] counts)
    {
        for (int i = 0;  i < _textPanels.Count; i++)
            _textPanels[i].gameObject.SetActive(false);

        if (counts is null)
            return;

        for (int i = 0; i < counts.Length; i++)
            counts[i].gameObject.SetActive(true);
    }
    #endregion
}
public enum Count
{
    SCORE,
    MONEY,
    HIGHT_SCORE,
}