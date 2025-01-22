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

    public GameObject endTxt;

    public int cardCount;
    public bool isCanOpen = false;
    public int level = 1 ;
    public int hiddenLevel = 4;


    int toplevel;
    int saveLevel;

    float time;
    float endtime = 0f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }


    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        //Load set
        string lv2 = PlayerPrefs.GetString("Loadlv2");
        string lv3 = PlayerPrefs.GetString("Loadlv3");

        if (lv2 == "2")
        {

            level = 2;
            saveLevel = PlayerPrefs.GetInt("LoadLv");
        }
        else if (lv3 == "3")
        {
            level = 3;
            saveLevel = PlayerPrefs.GetInt("LoadLv");
        }

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
            if (level >= toplevel)
            {
                if (toplevel >= saveLevel)
                {
                    GameLvSave();
                }
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
                if (level >= toplevel)
                {
                    if (toplevel >= saveLevel)
                    {
                        GameLvSave();
                    }
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
        PlayerPrefs.SetInt("GameLv", toplevel);
        PlayerPrefs.Save();
    }
}
