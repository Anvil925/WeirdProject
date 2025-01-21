using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public AudioSource audioSource;
    public AudioClip clip;


    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;

    public int level = 3;

    public int cardCount = 0;

    public GameObject endTxt;
    public GameObject nextTxt;

    float endtime = 0f;
    float time;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        if(level == 1)
        {
            time = 300.0f;
        }
        else if (level == 2)
        {
            time = 180.0f;
        }
        else if(level == 3)
        {
            time = 60.0f;
        }
    }

    void Update()
    {

        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N1");

        if(time <= endtime)
        {
            Time.timeScale = 0f;
            GameLvSave();
        }
    }
    
    public void GameLvSave()
    {
        PlayerPrefs.SetInt("PlayerLv", level);
        PlayerPrefs.Save();
    }

    public void Matched()
    {

    }
}
