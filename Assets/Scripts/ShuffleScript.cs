using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ShuffleScript : MonoBehaviour
{
    public List<int> shuffledList;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        // 오른쪽 Shift 키 입력 감지
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            shuffledList = CreateAndShuffleList();
        }
    }

    public List<int> CreateAndShuffleList()
    {
        int allcardAmount_shuffle = GameObject.Find("ObjectSpawner").GetComponent<ObjectMaker>().allCardAmount;
        // 1. 무작위 요소 개수 설정 (8~16)
        int elementCount = allcardAmount_shuffle;

        // 2. 리스트 생성
        List<int> numbers = new List<int>();
        for (int i = 1; i <= elementCount; i++)
        {
            numbers.Add(i);
        }

        Debug.Log("원본 리스트: " + string.Join(", ", numbers));

        // 3. Fisher-Yates 셔플
        Shuffle(numbers);

        // 4. 결과 출력
        Debug.Log("셔플된 리스트: " + string.Join(", ", numbers));

        return numbers;
    }
    public void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
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
        Debug.Log("Shuffle 리셋 사항 없음");
    }
}
