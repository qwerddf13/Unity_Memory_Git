using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreText : MonoBehaviour
{
    public TMP_Text scoreText;
    public ScoreManage scoreManage;
    public int t_score;
    void Start()
    {
        t_score = scoreManage.score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        GameManage.OnResetAll += ResetValues;
        ScoreManage.OnPlusScore += WriteScore;
    }

    void OnDisable()
    {
        GameManage.OnResetAll -= ResetValues;
        ScoreManage.OnPlusScore -= WriteScore;
    }

    void WriteScore()
    {
        t_score = scoreManage.score;
        scoreText.text = $"Score: {t_score}";
    }

    void ResetValues()
    {
        scoreText.text = $"Score: 0";
    }
}
