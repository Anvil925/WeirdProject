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
    public bool isCanOpen = false;
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

        if (true){} 
    }

    public void Matched()
    {
        if (firstTry.idx == secondTry.idx)
        {
            audioSource.PlayOneShot(clip);
            
            firstTry.DestroyCard();
            secondTry.DestroyCard();
            cardCount -= 2;

            // 카드를 모두 맞추면
            if (cardCount == 0)
            {
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
