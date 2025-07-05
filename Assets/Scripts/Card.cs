using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject spawner;
    public int cardNum;
    int cardSpriteNum;
    public int allCardAmount;

    public int myGridNum_x = 0; // 0 - 3
    public int myGridNum_y = 0; // 0 - 3
    int lastRow;
    int lastRowAmount;
    float gridPadding_x = 4, gridPadding_y = 5; //4, 5

    Vector2 awakeScale;
    public bool isCanClick;
    public Sprite[] sprites;
    void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        awakeScale = transform.transform.localScale;
        transform.position = transform.position;
        transform.localScale = transform.localScale;

        spawner = GameObject.Find("ObjectSpawner");
        cardNum = spawner.GetComponent<ObjectMaker>().toSetCardNum;
        cardSpriteNum = spawner.GetComponent<ObjectMaker>().spawnSpriteNum;

        myGridNum_x = (cardNum - 1) % 4;
        myGridNum_y = (cardNum - 1) / 4;

        isCanClick = true;

    }
    void Start()
    {

    }

    void Update()
    {

    }
    void LateUpdate()
    {
        SortCard();
    }
    void OnMouseOver()
    {
        if (isCanClick == true)
        {
            transform.localScale = new Vector2(awakeScale.x + 1, awakeScale.y + 1);
        }
    }
    void OnMouseDown()
    {
        Debug.Log("down");
    }
    void OnMouseUpAsButton()
    {
        if (isCanClick == true)
        {
            Debug.Log("uppp");
            StartCoroutine(flipCard());
        }
        else
        {
            Debug.Log("Noyou");
        }

    }
    void OnMouseExit()
    {
        if (isCanClick == true)
        {
            transform.localScale = new Vector2(awakeScale.x, awakeScale.y);
        }
    }
    void SortCard()
    {
        allCardAmount = spawner.GetComponent<ObjectMaker>().allCardAmount;
        lastRow = (allCardAmount - 1) / 4;
        lastRowAmount = allCardAmount % 4;
        if (myGridNum_y >= lastRow && lastRowAmount > 0)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(myGridNum_x * gridPadding_x - 9 + (lastRowAmount - 1) * -2, myGridNum_y * -gridPadding_y + lastRow * 2.5f), 50 * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(myGridNum_x * gridPadding_x - 15, myGridNum_y * -gridPadding_y + lastRow * 2.5f), 50 * Time.deltaTime);
    }
    IEnumerator flipCard()
    {
        isCanClick = false;
        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(transform.localScale.x - 1, transform.localScale.y);
        }

        if (spriteRenderer.sprite == sprites[0])
            spriteRenderer.sprite = sprites[cardSpriteNum];
        else
            spriteRenderer.sprite = sprites[0];

        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(transform.localScale.x + 1, transform.localScale.y);
        }

        yield return new WaitForSeconds(0.02f);
        transform.localScale = new Vector2(awakeScale.x, awakeScale.y);
        yield return new WaitForSeconds(0.2f);

        GameObject.Find("ChanceText").GetComponent<ChanceText>().smallChance--; // not clear
        isCanClick = true;

        yield break;
    }
}
