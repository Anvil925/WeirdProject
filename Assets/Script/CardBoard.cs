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
    public float Opacity = 1f;
    public float CardRotation = 0f;

    public static int RepeatCount = 15;

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

    GameObject[] gArr = new GameObject[RepeatCount];
    GameObject[] mArr = new GameObject[RepeatCount];

    Vector3 gameLastPos = Vector3.zero;
    Vector3 memberLastPos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
        CardInit();
        CreateCard(gameArr, gArr, StartPosition_game, Signed(true));
        CreateCard(memberArr, mArr, StartPosition_member, Signed(false));

        gameLastPos = gArr[^1].transform.position;
        memberLastPos = mArr[mArr.Length - 1].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        upVec.Normalize();
        MoveCard(gArr, Signed(false));
        MoveCard(mArr, Signed(true));

        RepositionCard(gArr, StartPosition_game, Signed(true));
        RepositionCard(mArr, StartPosition_member, Signed(false));
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
        for (int i = 0; i < RepeatCount; i++)
        {
            int idx = i % inArr.Length;
            GameObject go = Instantiate(inArr[idx], this.transform);

            // 카드 위치 지정
            float x = signed * i / upVec.y + startPos.x;
            float y = signed * i / upVec.x + startPos.y;

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
        }
    }

    // 숫자 부호를 bool 값으로 입력 받아, float값으로 출력
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
            Vector3 position = inArr[i].transform.position;
            if ((position.x < -4f && signed > 0) || (position.x > 4f && signed < 0))
            {
                float x = signed * RepeatCount / 2 * upVec.x + startPos.x;
                float y = signed * RepeatCount / 2 * upVec.y + startPos.y;
                Vector3 newPos = new Vector3(x, y, 0);
                Debug.Log($"\nnewPos : {newPos}\nupVec : {upVec}");
                inArr[i].transform.position = newPos;
            }
        }
    }
}
