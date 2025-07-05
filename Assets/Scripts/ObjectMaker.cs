using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ObjectMaker : MonoBehaviour
{
    public int test;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject cardShadePrefab;
    public int toSetCardNum = 0;
    public int allCardAmount = 0;
    public int spawnSpriteNum = 0;

    void SpawnCard(int cardspriteNum)
    {
        allCardAmount++;
        toSetCardNum++;
        spawnSpriteNum = cardspriteNum;
        Instantiate(cardPrefab);
        Debug.Log("Card was made.");
    }
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
            SpawnCard(spawnSpriteNum);
        }
    }
}
