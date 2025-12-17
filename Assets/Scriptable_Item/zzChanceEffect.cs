using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Effect/Chance")]
public class ChanceEffect : ItemEffects // 아직 효과가 직렬화 안 됨!!!!! 나중에 꼭 봐라
{
    public int chanceAmount;

    public override void Execute()
    {
        var chance = GameObject.Find("GameManager").GetComponent<ChanceScript>();
        chance.bigChance += chanceAmount;
    }
}
