using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        arr = arr.OrderBy(x => Random.Range(0f, 10f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject callCard = Instantiate(card, this.transform); // 카드를 보드의 위치에 호출
            callCard.name = i.ToString();
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 4.0f;

            callCard.transform.position = new Vector2(x, y);
            //go.GetComponent<Card>().Setting(arr[i]);
        }

        //GameManager.Instance.cardCount = arr.Length;
    }

}
