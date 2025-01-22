using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoard : MonoBehaviour
{
    public Vector2 StartPosition_game = new Vector2(-3, 0f);
    public Vector2 StartPosition_member = new Vector2(3, 2.2f);

    public Vector3 upVec = new Vector3(4, 2, 0);
    public float Speed = 0.5f;

    public GameObject game0;
    public GameObject game1;
    public GameObject game2;
    public GameObject game3;

    public GameObject member0;
    public GameObject member1;
    public GameObject member2;
    public GameObject member3;

    GameObject[] gameArr = new GameObject[4];
    GameObject[] memberArr = new GameObject[4];

    GameObject[] gArr = new GameObject[100];
    GameObject[] mArr = new GameObject[100];

    // Start is called before the first frame update
    void Start()
    {
        CardInit();
        CreateCard(gameArr, gArr, StartPosition_game, Signed(true));
        CreateCard(memberArr, mArr, StartPosition_member, Signed(false));
    }

    // Update is called once per frame
    void Update()
    {
        upVec.Normalize();
        MoveCard(gArr, Signed(false));
        MoveCard(mArr, Signed(true));
    }

    // 카드 입력
    private void CardInit()
    {
        gameArr[0] = game0;
        gameArr[1] = game1;
        gameArr[2] = game2;
        gameArr[3] = game3;
        memberArr[0] = member0;
        memberArr[1] = member1;
        memberArr[2] = member2;
        memberArr[3] = member3;
    }

    // 카드 생성 함수
    private void CreateCard(GameObject[] inArr, GameObject[] outArr, Vector2 startPos, float signed)
    {
        for (int i = 0; i < 100; i++)
        {
            int idx = i % 4;
            GameObject go = Instantiate(inArr[idx], this.transform);

            // 카드 위치 지정
            float x = signed * i / upVec.y + startPos.x;
            float y = signed * i / upVec.x + startPos.y;

            // 카드 transform 설정
            Vector3 cardPosition = new Vector3(x, y, 0);
            go.transform.position = cardPosition;
            go.transform.rotation = Quaternion.Euler(10, 0, 0);

            // update를 위해 반환
            outArr[i] = go;
        }
    }

    // 카드 움직이는 함수
    private void MoveCard(GameObject[] inArr, float signed)
    {
        for (int i = 0; i < inArr.Length; i++)
        {
            inArr[i].transform.position += signed * Speed * upVec * Time.deltaTime;
        }
    }

    // 숫자 부호를 bool 값으로 입력 받아, float값으로 출력
    private float Signed(bool b)
    {
        if (b)
            return 1f;
        else
            return -1f;
    }
}
