using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoard : MonoBehaviour
{
    public GameObject card;

    GameObject[] memberArr;
    GameObject[] gameArr;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 upVec = new Vector3(1, 1, 0);
        upVec.Normalize();

        for (int i = 0; i < 100; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i - 2f) * upVec.x;
            float y = (i - 2f) * upVec.y;

            Vector3 cardPosition = new Vector3(x, y, 0);
            go.transform.position = cardPosition;
            go.transform.rotation = Quaternion.Euler(10, 0, 0);

            int idx = i % 4 + 1;
            string path = "Images/GameCard/game ";

            Debug.Log($"\nnum = {i} \nidx = {idx}");
            go.GetComponent<Card>().OpenSceneSetting(idx, path);
            go.GetComponent<Card>().OpenCard();

            //memberArr[i] = go;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
