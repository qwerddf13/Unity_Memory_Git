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
        maxSelect = 2; // ChanceScript의 smallChance와 겹침
        score = 0;
        selectedCardNum = new List<int>();
    }
    void Update()
    {

    }
    public void ReceiveCardNum(int num)
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
        if (selectedCardNum[0] == selectedCardNum[1])
        {
            score++;
            Debug.Log("검사된 카드: " + string.Join(", ", selectedCardNum));
            Debug.Log("점수 올라감.");
            selectedCardNum.Clear();
        }
    }
}
