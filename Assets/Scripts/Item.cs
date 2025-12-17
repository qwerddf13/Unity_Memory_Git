using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Items[] items;
    public int itemNum;
    Items currItem;

    public TooltipTrigger tooltipTrigger;

    [SerializeField] GameObject buttonContainer;
    [SerializeField] RectTransform buttonContainerRect;
    [SerializeField] Button useButton;
    [SerializeField] Button sellButton;

    Vector2 startScale;

    void Awake()
    {
        currItem = items[itemNum];
        spriteRenderer.sprite = currItem.sprite;
        tooltipTrigger.itemScriptable = currItem;
    }
    
    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        currItem = items[itemNum];
        spriteRenderer.sprite = currItem.sprite;
        tooltipTrigger.itemScriptable = currItem;
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

            if (currItem.isItemActive)
            {
                useButton.interactable = true;
            }
            else
            {
                useButton.interactable = false;
            }

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

    public void UseItem()
    {
        if (currItem == null) return;

        currItem.Use();
    }
}
