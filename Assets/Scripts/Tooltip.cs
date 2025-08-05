using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutElement;
    public int charWrapLimit;
    public RectTransform rectTransform;
    public Vector2 position;

    public RectTransform canvasRectTransform;
    public RectTransform tooltipRectTransform;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        contentField.text = content;

        //int headerLength = headerField.text.Length;
        //int contentLength = contentField.text.Length;

        //layoutElement.enabled = (headerLength > charWrapLimit || contentLength > charWrapLimit) ? true : false;
    }

    void Update()
    {
        /*if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled = (headerLength > charWrapLimit || contentLength > charWrapLimit) ? true : false;
        }*/
    }

    void LateUpdate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform,
            mousePos,
            null, // Screen Space - Overlay일 경우
            out localPoint
        );

        Vector2 tooltipSize = tooltipRectTransform.sizeDelta;
        Vector2 canvasSize = canvasRectTransform.rect.size;

        Vector2 halfTooltip = tooltipSize * 0.5f;

        float minX = -canvasSize.x / 2;
        float maxX = canvasSize.x / 2 - halfTooltip.x * 2f;
        float minY = -canvasSize.y / 2 + halfTooltip.y * 2f;
        float maxY = canvasSize.y / 2;

        Vector2 clampedPos = new Vector2(
            Mathf.Clamp(localPoint.x, minX, maxX + 20),
            Mathf.Clamp(localPoint.y, minY - 20, maxY)
        );

        tooltipRectTransform.anchoredPosition = clampedPos;
    }
}
