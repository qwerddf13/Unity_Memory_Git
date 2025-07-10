using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManage : MonoBehaviour
{
    public List<int> startDeck = new List<int>{1,1,2,2,3,3,4,4};
    public List<int> currentDeck;
    void Start()
    {
        currentDeck = startDeck;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("덱 생성 신호 보냄");
            OnMakeCards?.Invoke(currentDeck);
        }
    }
    public static event Action<List<int>> OnMakeCards;
}
