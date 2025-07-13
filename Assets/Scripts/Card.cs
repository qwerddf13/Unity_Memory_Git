using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject spawner;
    public ScoreManage scoreManage;

    public int cardNum, cardSpriteNum, allCardAmount;
    public int myGridNum_x = 0; // 0 - 3
    public int myGridNum_y = 0; // 0 - 3
    int lastRow, lastRowAmount;
    float gridPadding_x = 4, gridPadding_y = 5; //4, 5

    Vector2 awakeScale;
    public bool isCanClick, isFlipedOpen, isMatched;
    public Sprite[] sprites;

    public List<int> shuffledList;
    void Start()
    {
        awakeScale = transform.transform.localScale;
        transform.position = transform.position;
        transform.localScale = transform.localScale;

        spawner = GameObject.Find("ObjectSpawner");
        cardNum = spawner.GetComponent<ObjectMaker>().toSetCardNum;
        cardSpriteNum = spawner.GetComponent<ObjectMaker>().spawnSpriteNum;

        scoreManage = GameObject.Find("GameManager").GetComponent<ScoreManage>();

        myGridNum_x = (cardNum - 1) % 4;
        myGridNum_y = (cardNum - 1) / 4;

        isCanClick = true;
    }
    void Update()
    {
        if (isCanClick == true)
            ChangeColor(1, 1, 1, 1);
        else
            ChangeColor(0.8f, 0.8f, 0.8f, 1);
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            shuffledList = GameObject.Find("CardShufflerOb").GetComponent<ShuffleScript>().shuffledList;
            cardNum = shuffledList[cardNum - 1];
            myGridNum_x = (cardNum - 1) % 4;
            myGridNum_y = (cardNum - 1) / 4;
        }
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
        Debug.Log("카드에 마우스를 누름");
    }
    void OnMouseUpAsButton()
    {
        if (isCanClick == true)
        {
            Debug.Log("카드에서 마우스를 떼어서 클릭됨");
            Debug.Log(cardSpriteNum);
            StartCoroutine(FlipCardCoroutine()); // 이거 안에 쓸데없이 기능이 많음
        }
        else
        {
            Debug.Log("카드 클릭 거부됨");
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
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(myGridNum_x * gridPadding_x - 9 + (lastRowAmount - 1) * -2, myGridNum_y * -gridPadding_y + lastRow * 2.5f), 100 * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(myGridNum_x * gridPadding_x - 15, myGridNum_y * -gridPadding_y + lastRow * 2.5f), 100 * Time.deltaTime);
    }
    void ChangeColor(float r, float g, float b, float alpha)
    {
        spriteRenderer.color = new Color(r, g, b, alpha);
    }
    IEnumerator FlipCardCoroutine()
    {
        isCanClick = false;
        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(transform.localScale.x - 1, transform.localScale.y);
        }

        if (spriteRenderer.sprite == sprites[0])
        {
            spriteRenderer.sprite = sprites[cardSpriteNum];
            isFlipedOpen = true;
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
            isFlipedOpen = false;
        }

        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(transform.localScale.x + 1, transform.localScale.y);
        }

        yield return new WaitForSeconds(0.02f);
        transform.localScale = new Vector2(awakeScale.x, awakeScale.y);
        yield return new WaitForSeconds(0.2f);

        if (isFlipedOpen == true)
        {
            isCanClick = false;
            OnCardClicked?.Invoke();
            scoreManage.ReceiveSelectedCardNum(cardSpriteNum);
        }
        else
        {
            isCanClick = true;
        }

        yield break;
    }
    public static event Action OnCardClicked;
    void OnEnable()
    {
        GameManage.OnResetAll += ResetValues;
        ScoreManage.OnCheckCard += CheckAndBindCard;
    }
    void OnDisable()
    {
        GameManage.OnResetAll -= ResetValues;
        ScoreManage.OnCheckCard -= CheckAndBindCard;
    }
    void ResetValues()
    {
        Debug.Log("카드가 리셋으로 인해 삭제됨");
        Destroy(gameObject);
    }
    void CheckAndBindCard(bool isPair)
    {
        if (isPair == true)
        {
            if (isFlipedOpen == true)
            {
                isMatched = true;
                isCanClick = false;
            }
        }
        else
        {
            if (isMatched == false && isFlipedOpen == true)
            {
                StartCoroutine(FlipCardCoroutine());
            }
        }
    }
}
