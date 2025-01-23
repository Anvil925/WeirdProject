using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class CardBoard : MonoBehaviour
{
    public Vector2 StartPosition_game = new Vector2(-3, 0f);
    public Vector2 StartPosition_member = new Vector2(3, 2.2f);

    public Vector3 upVec = new Vector3(4, 2, 0);
    public float Speed = 0.5f;
    public float CardDistance = 0.5f;
    public float Opacity = 1f;
    public float CardRotation = 0f;

    // 카드 생성 반복 횟수
    public static int RepeatCount = 20;

    public GameObject game0;
    public GameObject game1;
    public GameObject game2;
    public GameObject game3;
    public GameObject game4;

    public GameObject member0;
    public GameObject member1;
    public GameObject member2;
    public GameObject member3;
    public GameObject member4;

    // 각각 카드 초기화 리스트
    GameObject[] gameArr = new GameObject[5];
    GameObject[] memberArr = new GameObject[5];

    // 각각 생성된 이미지 리스트
    GameObject[] gArr = new GameObject[RepeatCount];
    GameObject[] mArr = new GameObject[RepeatCount];

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        CardInit();
        CreateCard(gameArr, gArr, StartPosition_game, Signed(true));
        CreateCard(memberArr, mArr, StartPosition_member, Signed(false));
        Debug.Log("CardBoard Start");
    }

    // Update is called once per frame
    void Update()
    {
        upVec.Normalize();
        MoveCard(gArr, Signed(false));
        MoveCard(mArr, Signed(true));

        RepositionCard(gArr, StartPosition_game, Signed(true));
        RepositionCard(mArr, StartPosition_member, Signed(false));

        Debug.Log(Time.timeScale);
    }

    // 카드 입력
    private void CardInit()
    {
        gameArr[0] = game0;
        gameArr[1] = game1;
        gameArr[2] = game2;
        gameArr[3] = game3;
        gameArr[4] = game4;

        memberArr[0] = member0;
        memberArr[1] = member1;
        memberArr[2] = member2;
        memberArr[3] = member3;
        memberArr[4] = member4;
    }

    // 카드 생성 함수
    private void CreateCard(GameObject[] inArr, GameObject[] outArr, Vector2 startPos, float signed)
    {
        upVec.Normalize();
        for (int i = 0; i < RepeatCount; i++)
        {
            int idx = i % inArr.Length;
            GameObject go = Instantiate(inArr[idx], this.transform);

            // 카드 위치 지정
            float x = signed * i * CardDistance * upVec.x + startPos.x;
            float y = signed * i * CardDistance * upVec.y + startPos.y;

            // 카드 transform 설정
            Vector3 cardPosition = new Vector3(x, y, 0);
            go.transform.position = cardPosition;
            go.transform.rotation = Quaternion.Euler(0, 0, CardRotation);

            // 투명도 설정
            SetOpacity(go, Opacity);

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
            inArr[i].transform.rotation = Quaternion.Euler(0, 0, CardRotation);
        }
    }

    // 숫자 부호를 bool 값으로 입력 받아, float값으로 출력
    // true: 양수, false: 음수
    float Signed(bool b)
    {
        return b ? 1f : -1f;
    }

    // 투명도 설정
    void SetOpacity(GameObject go, float opacity)
    {
        SpriteRenderer spriteRender = go.GetComponent<SpriteRenderer>();
        Color color = spriteRender.color;
        color.a = opacity;
        spriteRender.color = color;
    }

    // 위치 재조정
    void RepositionCard(GameObject[] inArr, Vector2 startPos, float signed)
    {
        for (int i = 0; i < RepeatCount; i++)
        {
            int num = i - 1;
            if (i == 0)
                num = inArr.Length - 1;

            Vector3 position = inArr[i].transform.position;

            // 게임 카드의 재조정 조건             || 팀원 카드의 재조정 조건
            if ((position.x < -3.5f && signed > 0) || (position.x > 3.5f && signed < 0))
            {
                float x = signed * CardDistance * upVec.x + inArr[num].transform.position.x;
                float y = signed * CardDistance * upVec.y + inArr[num].transform.position.y;
                Vector3 newPos = new Vector3(x, y, 0);
                //Debug.Log($"\nnewPos : {newPos}\nupVec : {upVec}");
                inArr[i].transform.position = newPos;
            }
        }
    }
}
