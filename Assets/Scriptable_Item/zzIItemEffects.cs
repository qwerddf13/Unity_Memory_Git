using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemEffects // 아직 효과가 직렬화 안 됨!!!!! 나중에 꼭 봐라
{
    public abstract void Execute(GameObject user);
}
