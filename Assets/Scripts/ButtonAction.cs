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
    }
    public static event Action OnNextStage;
}
