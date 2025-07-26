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
        OnStartStage?.Invoke();
    }

    void Update()
    {

    }

    public static event Action OnStartStage;
    public static event Action OnClearStage;

    void OnEnable()
    {
        ButtonAction.OnNextStage += StartStage;
        ScoreManage.OnPlusScore += TryClearStage;
    }

    void OnDisable()
    {
        ButtonAction.OnNextStage -= StartStage;
        ScoreManage.OnPlusScore -= TryClearStage;
    }

    void StartStage()
    {
        OnStartStage?.Invoke();
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
