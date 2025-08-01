using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class StageManage : MonoBehaviour
{
    public ScoreManage scoreManage;
    public int score, targetScore;
    public int stage, round;
    public const int maxStage = 4;
    public const int maxRound = 4;
    void Start()
    {
        targetScore = 4;
        stage = 1;
        round = 1;
        OnStartStage?.Invoke();
    }

    void Update()
    {

    }

    public static event Action OnStartStage;
    public static event Action OnClearStage;
    public static event Action OnResetAll;

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
        OnResetAll?.Invoke();
        OnStartStage?.Invoke();
    }

    void TryClearStage()
    {
        score = scoreManage.score;
        if (score >= targetScore)
        {
            ClearStage();
            OnClearStage?.Invoke();
        }
    }

    void ClearStage()
    {
        if (round < maxRound)
        {
            if (stage < maxStage)
            {
                stage++;
                Debug.Log("스테이지 완료. 스테이지 오름");
            }
            else
            {
                round++;
                stage = 1;
                Debug.Log("스테이지 완료 및 라운드 완료. 라운드 상승 및 스테이지 초기화.");
            }
        }
        else
        {
            Debug.Log("게임 클리어.");
        }
    }
}
