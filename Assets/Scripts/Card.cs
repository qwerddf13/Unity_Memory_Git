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
        isFlipedOpen = false;
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
            StartCoroutine(DoFlipCard()); // 이거 안에 쓸데없이 기능이 많음
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
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(myGridNum_x * gridPadding_x - 9 + (lastRowAmount - 1) * -2, myGridNum_y * -gridPadding_y + lastRow * 2.5f), 80 * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(myGridNum_x * gridPadding_x - 15, myGridNum_y * -gridPadding_y + lastRow * 2.5f), 80 * Time.deltaTime);
    }
    void ChangeColor(float r, float g, float b, float alpha)
    {
        spriteRenderer.color = new Color(r, g, b, alpha);
    }
    void BeforeFlipCard()
    {
        isCanClick = false;

        if (isFlipedOpen == true)
            isFlipedOpen = false;
        else
            isFlipedOpen = true;

        if (isFlipedOpen == true)
        {
            isCanClick = false;
            OnCardClicked?.Invoke();
            scoreManage.ReceiveSelectedCardNum(cardSpriteNum);
        }
    }
    IEnumerator DoFlipCard()
    {
        BeforeFlipCard();
        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale = new Vector2(transform.localScale.x - 1, transform.localScale.y);
        }

        if (spriteRenderer.sprite == sprites[0])
        {
            spriteRenderer.sprite = sprites[cardSpriteNum];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }

        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale = new Vector2(transform.localScale.x + 1, transform.localScale.y);
        }

        yield return new WaitForSeconds(0.01f);
        transform.localScale = new Vector2(awakeScale.x, awakeScale.y);
        yield return new WaitForSeconds(0.2f);

        if (isFlipedOpen == false)
        {
            OnEndAnimate?.Invoke();
        }

        yield break;
    }
    public static event Action OnCardClicked;
    public static event Action OnEndAnimate;
    void OnEnable()
    {
        GameManage.OnResetAll += ResetValues;
        ScoreManage.OnCheckCard += BindAllCard;
        ScoreManage.OnAnimateCard += CheckAndBindCard;
        OnEndAnimate += UnBindAllCard;
    }
    void OnDisable()
    {
        GameManage.OnResetAll -= ResetValues;
        ScoreManage.OnCheckCard -= BindAllCard;
        ScoreManage.OnAnimateCard -= CheckAndBindCard;
        OnEndAnimate -= UnBindAllCard;
    }
    void ResetValues()
    {
        Debug.Log("카드가 리셋으로 인해 삭제됨");
        Destroy(gameObject);
    }
    void BindAllCard(bool _)
    {
        isCanClick = false;
    }
    void UnBindAllCard()
    {
        if (isFlipedOpen == false) // 내가 뒷면이면
        {
            isCanClick = true; // 클릭 가능
        }
    }
    void CheckAndBindCard(bool isPair)
    {
        if (isPair == true) // 방금 깐 카드가 짝이 맞고
        {
            if (isFlipedOpen == true) // 내가 앞면 카드면
            {
                isMatched = true;   // 난 짝맞음이 되고 클릭 불가
                isCanClick = false;
            }
            else // 내가 뒷면 카드면
            {
                isCanClick = true; // 클릭 가능
            }
        }
        else // 방금 깐 카드가 짝이 안 맞고
        {
            if (isMatched == false && isFlipedOpen == true)
            { // 내가 짝맞음이 아니고 내가 앞면 카드면
                StartCoroutine(DoFlipCard()); // 다시 뒤집힘
            }
        }
    }
}
