using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Items[] items;
    public TooltipTrigger tooltipTrigger;

    Vector2 startScale;

    void Awake()
    {
        if (spriteRenderer != null)
            spriteRenderer.sprite = items[0].sprite;
        
        tooltipTrigger.itemScriptable = items[0];
    }
    
    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        
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
