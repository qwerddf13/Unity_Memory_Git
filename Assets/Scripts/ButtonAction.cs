using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void NextStage()
    {
        OnNextStage?.Invoke();
        gameObject.SetActive(false);
        Debug.Log("다음 스테이지 버튼 눌리고 사라짐" + gameObject.activeSelf);
    } // 버튼을 비활성화 안 하고 자기 자신(ButtonManager)를 비활성화시킴
    // 버튼 게임오브젝트 만들어서 집어넣자
    public static event Action OnNextStage;
}
