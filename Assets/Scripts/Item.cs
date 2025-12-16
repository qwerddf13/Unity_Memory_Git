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
    [SerializeField] GameObject buttonContainer;
    [SerializeField] RectTransform buttonContainerRect;

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

    void OnMouseUpAsButton()
    {
        if (buttonContainer.activeSelf == false)
        {
            ItemWorldPosToCanvasPos();
            buttonContainer.SetActive(true);
        }
        else
        {
            buttonContainer.SetActive(false);
        }
    }

    void ItemWorldPosToCanvasPos()
    {
        Vector2 worldPos = transform.position; 
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPos);
        buttonContainerRect.position = screenPoint;
    }
}
