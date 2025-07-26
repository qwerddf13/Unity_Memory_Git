using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            EndGame();
        }
    }

    public static event Action OnResetAll;

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    public void EndGame()
    {
        Debug.Log("게임 종료. 리셋 시작");
        OnResetAll?.Invoke();
    }
}

