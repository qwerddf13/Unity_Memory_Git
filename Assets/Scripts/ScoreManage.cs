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
        }
    }
    public void CheckAndScore()
    {
        Debug.Log("검사된 카드: " + string.Join(", ", selectedCardNum));
        OnCheckCard?.Invoke(); // 두 개 뒤집히면 무조건 검사
        if (selectedCardNum[0] == selectedCardNum[1])
        {
            score++;
            Debug.Log("점수: " + score);
            selectedCardNum.Clear();
        }
    }
    public static event Action OnCheckCard;
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
