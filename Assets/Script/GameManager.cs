using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
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

    int toplevel;
    int saveLevel;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        isCanOpen = true;

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

        //level set
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

        //�������� �ð��� 1/3 ���� �ð� �ȳ��������ε� �����ϼŵ� �˴ϴ�.
        if ((timeLimit / 3) >= time) 
        {
            timeAnim.SetBool("isTimeLimit", true);
            if (time <= endtime)
            {
                Time.timeScale = 0f;
                if (level >= saveLevel)
                {

        if ( time <=endtime)
        {
            Time.timeScale = 0f;
            if (level >= toplevel)
            {
                if (toplevel >= saveLevel)
                {
                    toplevel = saveLevel;
                    GameLvSave();
                }
            }
        }

    }


    public void Matched()
    {
        if (firstTry.idx == secondTry.idx) // �� ī�尡 ������ ���� 
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
                        toplevel = saveLevel;
                        GameLvSave();
                    }
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
        PlayerPrefs.SetInt("GameLv", toplevel);
        PlayerPrefs.Save();
    }
}
