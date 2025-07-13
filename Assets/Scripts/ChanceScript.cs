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
        Card.OnCardClicked += UseSmallChance;
        ScoreManage.OnCheckCard += UseBigChance;
    }
    void OnDisable()
    {
        GameManage.OnResetAll -= ResetValues;
        Card.OnCardClicked -= UseSmallChance;
        ScoreManage.OnCheckCard -= UseBigChance;
    }
    void UseSmallChance() // 쓸모없음
    {
        smallChance--;
    }
    void UseBigChance(bool isPair)
    {
        if (isPair == false)
        {
            bigChance--;
        }
        chanceText.text = $"Chance: {bigChance}";
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
