using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManage : MonoBehaviour
{
    public ScoreManage scoreManage;
    public int score, targetScore;
    void Start()
    {
        targetScore = 4;
    }

    void Update()
    {

    }
    public static event Action OnClearStage;

    void OnEnable()
    {
        ScoreManage.OnPlusScore += TryClearStage;
    }

    void OnDisable()
    {
        ScoreManage.OnPlusScore -= TryClearStage;
    }

    void TryClearStage()
    {
        score = scoreManage.score;
        if (score >= targetScore)
        {
            OnClearStage?.Invoke();
            ClearStage();
        }
    }

    void ClearStage()
    {
        Debug.Log("스테이지 리셋 시작.");
        
    }
    
}
