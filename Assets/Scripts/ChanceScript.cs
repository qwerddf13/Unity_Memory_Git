using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChanceText : MonoBehaviour
{
    public TMP_Text chanceText;
    public int bigChance = 4;
    public int smallChance = 2; // 0 - 2
    void Start()
    {
        
    }

    void Update()
    {
        if (smallChance == 0)
        {
            smallChance = 2;
            bigChance--;
        }
        chanceText.text = $"Chance: {bigChance}";
    }
}
