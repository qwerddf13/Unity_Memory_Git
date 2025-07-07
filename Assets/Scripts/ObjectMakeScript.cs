using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ObjectMaker : MonoBehaviour
{
    public int test;
    [SerializeField] private GameObject cardPrefab;
    public int toSetCardNum = 0;
    public int allCardAmount = 0;
    public int spawnSpriteNum = 1;

    void Awake()
    {

    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SpawnCard(1);
        }
    }
    void SpawnCard(int cardspriteNum)
    {
        allCardAmount++;
        toSetCardNum++;
        spawnSpriteNum = cardspriteNum;
        Instantiate(cardPrefab);
        Debug.Log("카드 생성됨.");
    }
    void OnEnable()
    {
        GameManager.OnResetAll += ResetValues;
    }

    void OnDisable()
    {
        GameManager.OnResetAll -= ResetValues;
    }

    void ResetValues()
    {
        allCardAmount = 0;
        toSetCardNum = 0;
        spawnSpriteNum = 1;
        Debug.Log("ObjectMake 리셋됨");
    }
}
