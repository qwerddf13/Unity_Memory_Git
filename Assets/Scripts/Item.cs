using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Item : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Items[] items;
    public int itemNum;
    public TooltipTrigger tooltipTrigger;

    Vector2 startScale;

    void Awake()
    {
        spriteRenderer.sprite = items[itemNum].sprite;
        
        tooltipTrigger.itemScriptable = items[itemNum];
    }
    
    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        spriteRenderer.sprite = items[itemNum].sprite;
        
        tooltipTrigger.itemScriptable = items[itemNum];
    }

    void OnMouseOver()
    {
        transform.localScale = startScale * 1.1f;
    }

    void OnMouseExit()
    {
        transform.localScale = startScale;
    }
}
