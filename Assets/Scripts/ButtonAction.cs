using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public GameObject Button_nextStage;
    void Start()
    {

    }

    void Update()
    {

    }

    public void NextStage()
    {
        OnNextStage?.Invoke(); // 스테이지매니저에게만
        Button_nextStage.SetActive(false);
        Debug.Log("다음 스테이지 버튼 눌리고 사라짐");
    }
    public static event Action OnNextStage;
}
// 스테이지 완료 후 일부 변수 리셋하기