using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Game/Item")]
public class Items : ScriptableObject
{
    public Sprite sprite;
    public bool isItemActive = false;

    public string itemName;

    [Multiline()]
    public string description;

    public ItemEffects[] effects; // 아직 효과가 직렬화 안 됨!!!!! 나중에 꼭 봐라

    public void Use(GameObject user)
    {
        foreach (var effect in effects)
            effect.Execute(user);
    }
}