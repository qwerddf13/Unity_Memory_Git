using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMaker : MonoBehaviour
{
    void Start()
    {
        CreateShadow();
    }

    void CreateShadow()
    {
        GameObject shadow = new GameObject("Shadow");
        shadow.transform.parent = transform;
        shadow.transform.localPosition = new Vector2(transform.localPosition.x, -1); // 살짝 아래로

        SpriteRenderer originalSR = GetComponent<SpriteRenderer>();
        SpriteRenderer shadowSR = shadow.AddComponent<SpriteRenderer>();

        shadowSR.sprite = originalSR.sprite;
        shadowSR.sortingLayerID = originalSR.sortingLayerID;
        shadowSR.sortingOrder = originalSR.sortingOrder - 1; // 본체보다 뒤에 그리기

        shadowSR.color = new Color(0f, 0f, 0f, 0.5f); // 검정색 + 반투명
    }
}
