using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChanceScript : MonoBehaviour
{
    public TMP_Text chanceText;
    public ScoreManage scoreManage;
    public int bigChance, smallChance;
    public int maxSelect2;

    void Start()
    {
        smallChance = 2; // 쓸모없음
        bigChance = 4;
        maxSelect2 = scoreManage.maxSelect;
    }
    void Update()
    {
        
    }
    void OnEnable()
    {
        GameManage.OnResetAll += ResetValues;
        StageManage.OnStartStage += ResetValues;
        Card.OnCardClicked += LoseSmallChance;
        ScoreManage.OnCheckCard += LoseBigChance;
        ScoreManage.OnAnimateCard += WriteBigChance;
        StageManage.OnClearStage += ClearStage;
    }
    void OnDisable()
    {
        GameManage.OnResetAll -= ResetValues;
        StageManage.OnStartStage -= ResetValues;
        Card.OnCardClicked -= LoseSmallChance;
        ScoreManage.OnCheckCard -= LoseBigChance;
        ScoreManage.OnAnimateCard += WriteBigChance;
        StageManage.OnClearStage -= ClearStage;
    }
    void LoseSmallChance() // 쓸모없음
    {
        smallChance--;
    }
    void LoseBigChance(bool isPair)
    {
        if (isPair == false)
        {
            bigChance--;
        }
    }
    void WriteBigChance(bool _)
    {
        chanceText.text = $"Chance: {bigChance}";
    }
    void ClearStage()
    {
        smallChance = 2;
    }

    void ResetValues()
    {
        maxSelect2 = scoreManage.maxSelect;
        bigChance = 4;
        smallChance = maxSelect2;
        chanceText.text = $"Chance: {bigChance}";
        Debug.Log("Chance 텍스트 리셋됨.");
    }
}
