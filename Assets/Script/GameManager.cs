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

    public Animator timeAnim;

    public GameObject endTxt;

    public int cardCount = 0;
    public bool isCanOpen = true;
    float time = 0.0f;
    float timeLimit = 0.0f;
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

        if (level == 1)
        {
            timeLimit = 300.0f;
        }
        else if (level == 2)
        {
            timeLimit = 180.0f;
        }
        else if (level == 3)
        {
            timeLimit = 60.0f;
        }
        else
        {
            timeLimit = 60.0f;
        }
        time = timeLimit;
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N1");

        //스테이지 시간의 1/3 보다 시간 안남았을때인데 수정하셔도 됩니다.
        if ((timeLimit / 3) >= time) 
        {
            timeAnim.SetBool("isTimeLimit", true);
            if (time <= endtime)
            {
                Time.timeScale = 0f;
                if (level >= saveLevel)
                {
                    GameLvSave();
                }
            }
        }
    }

    public void Matched()
    {
        if (firstTry.idx == secondTry.idx) // 두 카드가 같으면 삭제 
        {
            audioSource.PlayOneShot(clip);
            
            firstTry.DestroyCard();
            secondTry.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                Time.timeScale = 0.0f;
                level += 1;
                if (level >= saveLevel)
                {
                    GameLvSave();
                }
            }
        }
        else
        {
            //firstTry.anim.SetBool("isOpen", false);
            //secondTry.anim.SetBool("isOpen", false);
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
