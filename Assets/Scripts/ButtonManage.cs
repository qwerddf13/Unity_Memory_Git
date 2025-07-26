using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManage : MonoBehaviour
{
    public GameObject Button_nextStage;
    void Start()
    {
        Button_nextStage.SetActive(false);
    }

    
    void Update()
    {

    }

    void OnEnable()
    {
        StageManage.OnClearStage += ShowNextStageButton;
    }

    void OnDisable()
    {
        StageManage.OnClearStage -= ShowNextStageButton;
    }

    void ShowNextStageButton()
    {
        StartCoroutine(DoShowNextStageButton());
    }

    IEnumerator DoShowNextStageButton()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(CheckCardExist);

        Button_nextStage.SetActive(true);

        Debug.Log("다음 스테이지 버튼 나타냄");
    }

    bool CheckCardExist()
    {
        Card[] cardsInScene = FindObjectsOfType<Card>();

        if (cardsInScene.Length == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
