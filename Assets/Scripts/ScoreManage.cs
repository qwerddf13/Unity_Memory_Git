using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManage : MonoBehaviour
{
    public int maxSelect, score;
    public List<int> selectedCardNum;
    public bool isMatched_Score;
    void Start()
    {
        maxSelect = 2;
        score = 0;
        selectedCardNum = new List<int>();
    }
    void Update()
    {

    }
    public void ReceiveSelectedCardNum(int num)
    {
        selectedCardNum.Add(num);
        Debug.Log("다음 카드가 리스트에 들어감: " + num);
        if (selectedCardNum.Count == maxSelect)
        {
            CheckAndScore();
            Invoke("AnimateCard", 1f);
        }
    }
    public void CheckAndScore()
    {
        Debug.Log("검사된 카드: " + string.Join(", ", selectedCardNum));

        if (selectedCardNum[0] == selectedCardNum[1])
        {
            score++;
            OnCheckCard?.Invoke(true);
            isMatched_Score = true; // 짝 맞으면 true, 짝 안 맞으면 false
        }
        else
        {
            OnCheckCard?.Invoke(false);
            isMatched_Score = false;
        }
        Debug.Log("점수: " + score);
        selectedCardNum.Clear();
    }
    void AnimateCard()
    {
        if (isMatched_Score == true)
        {
            OnAnimateCard?.Invoke(true);
        }
        else
        {
            OnAnimateCard?.Invoke(false);
        }
    }

    public static event Action<bool> OnCheckCard;
    public static event Action<bool> OnAnimateCard;
    void OnEnable()
    {
        GameManage.OnResetAll += ResetValues;
    }
    void OnDisable()
    {
        GameManage.OnResetAll -= ResetValues;
    }
    void ResetValues()
    {
        score = 0;
        selectedCardNum.Clear();
        Debug.Log("ScoreManage 점수 및 리스트 리셋됨");
    }
}
