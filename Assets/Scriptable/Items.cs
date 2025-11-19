using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Game/Item")]
public class Items : ScriptableObject
{
    public Sprite sprite;

    public string itemName;

    [Multiline()]
    public string description;
}