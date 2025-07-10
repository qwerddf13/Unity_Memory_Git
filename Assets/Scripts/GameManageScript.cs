using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            EndGame();
        }
    }
    public static event Action OnResetAll;
    public void EndGame()
    {
        Debug.Log("게임 종료. 리셋 시작");
        OnResetAll?.Invoke(); // 등록된 모든 리스너에게 신호 보냄
    }
}

