using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    public Text CurrentTimeTxt;
    public Text BestTimeTxt;


    public GameObject endTxt;
    public GameObject Result;
    public GameObject FailMsg;
    public GameObject CrealMSg;
    public int cardCount = 0;
    public bool isCanOpen = true;
    private float startTime;  // 게임 시작 시간
    private float elapsedTime; // 흘러간 시간
    private float bestTime;   // 최고 기록
  

    float time = 0.0f;
    float endtime = 0f;
    

    public int level;
    public int hiddenLevel = 4;

    int saveLevel;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        saveLevel = PlayerPrefs.GetInt("LoadLv");
        level = saveLevel;
        isCanOpen = true;

        bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue); // 최고 기록 로드
        // 게임 시작 시간 초기화
        startTime = Time.time;
        if (level == 1)
        {
            time = 300.0f;
        }
        else if (level == 2)
        {
            time = 180.0f;

        }
        else if (level == 3)
        {
            time = 60.0f;

        }
        else
        {
            time = 30.0f;

        }
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N1");
        
        if (time <= endtime)
        {
            Time.timeScale = 0f;
            Result.SetActive(true);
            FailMsg.SetActive(true);
            if (level >= saveLevel)
            {
                GameLvSave();
            }
        }
    }

    public void Matched()
    {
        if (firstTry.idx == secondTry.idx)
        {
            audioSource.PlayOneShot(clip);
            
            firstTry.DestroyCard();
            secondTry.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                Time.timeScale = 0.0f;
                level += 1;
                // 흘러간 시간 계산
                elapsedTime = Time.time - startTime;
                // 최고 기록 갱신
                if (elapsedTime < bestTime)
                {
                bestTime = elapsedTime;
                PlayerPrefs.SetFloat("BestTime", bestTime); // 최고 기록 저장
                PlayerPrefs.Save();
                }
                // UI 업데이트
                CurrentTimeTxt.text = $"{elapsedTime:F1}초";
                BestTimeTxt.text = $"{bestTime:F1}초";
                Result.SetActive(true);
                CrealMSg.SetActive(true);
                if (level >= saveLevel)
                {
                    GameLvSave();
                }
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

    public void GameLvSave()
    {
        PlayerPrefs.SetInt("GameLv", level);
        PlayerPrefs.Save();
    }

}
