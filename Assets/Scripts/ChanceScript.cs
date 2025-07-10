using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChanceScript : MonoBehaviour
{
    public TMP_Text chanceText;
    public int bigChance, smallChance;

    void Start()
    {
        smallChance = 2;
        bigChance = 4;
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
