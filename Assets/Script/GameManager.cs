using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioSource audioSource;
    public AudioClip clip;

    public Card firstTry;
    public Card secondTry;

    public Text timeTxt;

    public int cardCount = 0;
    public bool isCanOpen = true;
    float time = 0.0f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }


    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (true){} // 단계마다 다른 시간제한 게임오버 구현
    }

    public void Matched()
    {
        if (firstTry.idx == secondTry.idx)
        {
            firstTry.DestroyCard();
            secondTry.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                //카드를 모두 다 맞추어서 클리어 했을때
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstTry.CloseCard();
            secondTry.CloseCard();
        }
        firstTry = null;
        secondTry = null;
    }

}
