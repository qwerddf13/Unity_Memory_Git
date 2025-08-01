using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundText : MonoBehaviour
{
    public TMP_Text roundText;
    public StageManage stageManage;
    public int round, stage;
    public const int maxStage = 4;
    public const int maxRound = 4;
    void Start()
    {
        WriteRoundAndStage();
    }

    void Update()
    {

    }

    void OnEnable()
    {
        StageManage.OnClearStage += WriteRoundAndStage;
    }

    void OnDisable()
    {
        StageManage.OnClearStage -= WriteRoundAndStage;
    }

    void WriteRoundAndStage()
    {
        round = stageManage.round;
        stage = stageManage.stage;
        roundText.text = $"Round: {round}/{maxRound}\nStage: {stage}/{maxStage}";
    }
}
