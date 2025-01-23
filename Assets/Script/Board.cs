using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;
    public bool Debug_Mode = false;
    public int Level = 1;

    void Start()
    {
        // Level 1일때
        int[] arr = { 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4 };

        if (Level == 2)
        {
            arr = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 , 6, 6, 6, 6, 7, 7, 7, 7};
        }
        else if (Level == 3)
        {
            arr = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        }

        arr = arr.OrderBy(x => Random.Range(0f, 10f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject callCard = Instantiate(card, this.transform); 
            callCard.name = i.ToString();
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 4.0f;

            callCard.transform.position = new Vector2(x, y);
            callCard.GetComponent<Card>().Setting(arr[i]);
            callCard.GetComponent<Card>().LevelValue = Level;
            callCard.GetComponent<Card>().Debug_Mode = Debug_Mode;
        }
        GameManager.Instance.cardCount = arr.Length;
    }

}
