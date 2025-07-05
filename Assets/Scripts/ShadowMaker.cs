using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMaker : MonoBehaviour
{
    void Start()
    {
        CreateShadow(gameObject);
    }

    void CreateShadow(GameObject target)
    {
        GameObject shadow = Instantiate(target, target.transform.position, target.transform.rotation, target.transform);
    
        SpriteRenderer sr = shadow.GetComponent<SpriteRenderer>();
        sr.color = new Color(0f, 0f, 0f, 0.5f); // 반투명 검은색
        shadow.transform.localPosition += new Vector3(0.1f, -0.1f, 0f); // 살짝 아래/뒤로
        shadow.transform.localScale = new Vector3(1f, 0.9f, 1f); // 약간 찌그러트림
        shadow.name = "Shadow";
    }
}
