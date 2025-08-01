using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ObjectMaker : MonoBehaviour
{
    public int test;
    [SerializeField] private GameObject cardPrefab;
    public Transform canvas;
    public int toSetCardNum = 0;
    public int allCardAmount = 0;
    public int spawnSpriteNum = 1;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnEnable()
    {
        GameManage.OnResetAll += ResetValues;
        StageManage.OnResetAll += ResetValues;
        DeckManage.OnMakeCards += DoCoroutine;
    }

    void OnDisable()
    {
        GameManage.OnResetAll -= ResetValues;
        StageManage.OnResetAll -= ResetValues;
        DeckManage.OnMakeCards -= DoCoroutine;
    }
    void DoCoroutine(List<int> forDoList)
    {
        StartCoroutine(SpawnDeck(forDoList));
    }
    IEnumerator SpawnDeck(List<int> deck)
    {
        Debug.Log("덱 생성됨: " + string.Join(",", deck));
        for (int i = 0; i < deck.Count; i++)
        {
            SpawnCard(deck[i]);
            yield return new WaitForSeconds(0.1f);

        }
        yield break;
    }

    void SpawnCard(int cardspriteNum)
    {
        allCardAmount++;
        toSetCardNum++;
        spawnSpriteNum = cardspriteNum;
        Instantiate(cardPrefab);
        Debug.Log("카드 생성됨: " + cardspriteNum);
    }
    void ResetValues()
    {
        allCardAmount = 0;
        toSetCardNum = 0;
        spawnSpriteNum = 1;
        Debug.Log("ObjectMake 리셋됨");
    }
}
