using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Items itemScriptable;

    public string header;

    [Multiline()]
    public string content;

    public void Start()
    {
        if (itemScriptable != null)
        {
            header = itemScriptable.itemName;
            content = itemScriptable.description;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(content, header);
    }

    void OnMouseOver()
    {
        TooltipSystem.Show(content, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }
    void OnMouseExit()
    {
        TooltipSystem.Hide();
    }
}
