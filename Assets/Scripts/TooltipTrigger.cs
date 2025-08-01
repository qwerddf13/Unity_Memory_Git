using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    static LTDescr delay;
    public string header;

    [Multiline()]
    public string content;

    public Vector2 pos;
    public float paddingY;

    void Awake()
    {
        pos = transform.position;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        pos = transform.position;
        TooltipSystem.Show(pos, paddingY, content, header);
    }

    void OnMouseOver()
    {
        pos = transform.position;
        TooltipSystem.Show(pos, paddingY, content, header);
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
