using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Effect/Shuffle")]
public class zzShuffleEffect : ItemEffects // 아직 효과가 직렬화 안 됨!!!!! 나중에 꼭 봐라
{
    public override void Execute()
    {
        GameObject.Find("GameManager").GetComponent<ShuffleScript>().CreateAndShuffleList();
    }
}
