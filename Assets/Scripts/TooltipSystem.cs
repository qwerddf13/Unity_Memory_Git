using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    static TooltipSystem current;
    public Tooltip tooltip;

    public void Awake()
    {
        current = this;
    }

    public static void Show(Vector2 pos, float paddingY, string content, string header = "")
    {
        current.tooltip.SetText(content, header);
        current.tooltip.SetPosition(pos, paddingY);
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }
}
