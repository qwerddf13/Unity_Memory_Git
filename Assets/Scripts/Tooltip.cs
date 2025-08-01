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

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > charWrapLimit || contentLength > charWrapLimit) ? true : false;
    }

    public void SetPosition(Vector2 pos, float paddingY)
    {
        position = new Vector2(pos.x, pos.y + paddingY);
        position = Camera.main.WorldToScreenPoint(position);
    }

    void Update()
    {
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled = (headerLength > charWrapLimit || contentLength > charWrapLimit) ? true : false;
        }

        rectTransform.position = position;
    }
}
