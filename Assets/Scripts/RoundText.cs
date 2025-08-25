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
        ButtonAction.OnNextStage += WriteRoundAndStage;
    }

    void OnDisable()
    {
        ButtonAction.OnNextStage -= WriteRoundAndStage;
    }

    void WriteRoundAndStage()
    {
        round = stageManage.round;
        stage = stageManage.stage;
        roundText.text = $"라운드: {round}/{maxRound}\n스테이지: {stage}/{maxStage}";
    }
}
