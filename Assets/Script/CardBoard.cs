using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoard : MonoBehaviour
{
    public GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = i * 1.4f - 2.1f;
            float y = i * 1.4f - 2f;

            Vector3 cardPosition = new Vector3(x, y, 0);
            go.transform.position = cardPosition;

            int idx = i % 4 + 1;
            string path = "Images/MemberCard/";

            Debug.Log($"num = {i} \nidx = {idx}");
            go.GetComponent<Card>().OpenSceneSetting(idx, path);
            go.GetComponent<Card>().OpenCard(false);

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
