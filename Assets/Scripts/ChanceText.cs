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
    public Animator animator;
    public int bigChance, smallChance;
    public int maxSelect2; // 변수 정리 좀 해라
    bool isBigChanceUsed;

    void Start()
    {
        smallChance = 2; // 쓸모없음
        bigChance = 4;
        isBigChanceUsed = false;
        maxSelect2 = scoreManage.maxSelect;
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        GameManage.OnResetAll += ResetValues;
        StageManage.OnResetAll += ResetValues;
        Card.OnCardClicked += LoseSmallChance;
        ScoreManage.OnCheckCard += LoseBigChance;
        ScoreManage.OnAnimateCard += WriteBigChance;
        StageManage.OnClearStage += ClearStage;
    }

    void OnDisable()
    {
        GameManage.OnResetAll -= ResetValues;
        StageManage.OnResetAll -= ResetValues;
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
            isBigChanceUsed = true;
        }
    }

    void WriteBigChance(bool _)
    {
        chanceText.text = $"기회: {bigChance}";
        if (isBigChanceUsed == true)
        {
            AnimateBox();
        }
    }

    public void AnimateBox()
    {
        animator.SetTrigger("UseChance");
        isBigChanceUsed = false;
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
        chanceText.text = $"기회: {bigChance}";
        Debug.Log("Chance 텍스트 리셋됨.");
    }
}
