using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioManager audioManager;
    public AudioSource audioSource;
    public AudioClip matchClip;
    public AudioClip failClip;
    public AudioClip successClip;

    public Card firstTry;
    public Card secondTry;

    public Text timeTxt;
    public Text CurrentTimeTxt;
    public Text BestTimeTxt;

    public Animator timeAnim;

    public GameObject endTxt;
    public GameObject Result;
    public GameObject retry;
    public GameObject nextLv;
    public GameObject FailMsg;
    public GameObject CrealMSg;
    public GameObject Achievements;
    public SceneManager sceneManager;
    public int cardCount = 0;
    public bool isCanOpen = true;

    private float startTime;  
    private float elapsedTime; 
    private float bestTime;   
    private bool pitchChanged = false;

    float time = 0.0f;
    float timeLimit = 0.0f;
    float endtime = 0f;

    int hiddenLv;
    int level = 1;
    int toplevel;

    int saveLevel;

    private void Awake()
    {   
        if (Instance == null) 
        {
            Instance = this;

        }

    }

        void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        isCanOpen = true;

        string lv2 = PlayerPrefs.GetString("Loadlv2");
        string lv3 = PlayerPrefs.GetString("Loadlv3");
        string Lvh = PlayerPrefs.GetString("Loadlvh");
        bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);
        if (lv2 == "2")
        {
            level = 2;
        }
        else if (lv3 == "3")
        {
            level = 3;           
        }
        else if (Lvh == "h")
        {
            hiddenLv = 1;
        }

        startTime = Time.time;   
        if (hiddenLv == 1)
        {
            timeLimit = 210.0f;
        }
        else if (level == 1)
        {
            timeLimit = 180.0f;
        }
        else if (level == 2 )
        {
            timeLimit = 120.0f;
        }
        else if (level == 3)
        {
            timeLimit = 90.0f;

        }
        time = timeLimit;
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Time.timeScale != 0f)
            time -= Time.deltaTime;
        time = Mathf.Max(time, 0.0f);
        timeTxt.text = time.ToString("N1");
                
        {
            time = Mathf.Max(time - Time.deltaTime, 0.0f);
            timeTxt.text = time.ToString("N1");
        }
        
        if ((timeLimit / 3) >= time)
        {
            timeAnim.SetBool("isTimeLimit", true);
            if (time <= endtime)
            {
                Time.timeScale = 0f;
                if (level >= toplevel && saveLevel <= toplevel)
                {
                    saveLevel = toplevel;
                    GameLvSave();
                }
            }
        }
        
        if (time <= (timeLimit / 3) && !pitchChanged)
        {
            StartCoroutine(GraduallyIncreasePitch(1.5f, 3.0f));
            pitchChanged = true;
        }
        
        if (time <= endtime)
        {
            Time.timeScale = 0f;
            Result.SetActive(true);
            nextLv.SetActive(true);
            if (cardCount > 0)
            {  
                audioSource.PlayOneShot(failClip, 0.02f);
                FailMsg.SetActive(true);
            }

            if (level <= toplevel)
            {
                if (saveLevel <= toplevel)
                {
                    saveLevel = toplevel;
                    GameLvSave();
                }
                if (saveLevel == 3)
                {
                    hiddenLv = 1;
                }
            }
        }
    }

    public void Matched()
    {
        if (firstTry.idx == secondTry.idx)  
        {
            audioSource.PlayOneShot(matchClip);
            
            firstTry.DestroyCard();
            secondTry.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                audioSource.PlayOneShot(successClip, 0.05f);
                Invoke("TimeStop", 2f);
                Time.timeScale = 0.0f;
                level += 1;

                Scene scene = GetCurrentScene();
                if (scene.name == "Main1Scene")
                {
                    PlayerPrefs.SetString("Main1Scene", scene.name);
                    PlayerPrefs.SetString("ContinueBtn", "ContinueBtn");
                }
                else if (scene.name == "Main2Scene")
                {
                    PlayerPrefs.SetString("Main2Scene", scene.name);
                    Debug.Log("main2Clear");
                    Debug.Log(PlayerPrefs.HasKey("Main2Scene"));
                }
                else if (scene.name == "Main3Scene")
                {
                    Achievements.SetActive(true);
                    Animator achAnim = Achievements.GetComponent<Animator>();
                    achAnim.SetTrigger("isActivate");
                    audioSource.PlayOneShot(matchClip);
                }

                elapsedTime = Time.time - startTime;

                if (level > 3)
                {
                    level = 3;
                }
                if (elapsedTime < bestTime)
                {
                    bestTime = elapsedTime;
                    PlayerPrefs.SetFloat("BestTime", bestTime);
                    PlayerPrefs.Save();
                }
                CrealMSg.SetActive(true);
                CurrentTimeTxt.text = $"{elapsedTime:F1}";
                BestTimeTxt.text = $"{bestTime:F1}";
                audioSource.ignoreListenerPause = true;
                audioSource.PlayOneShot(successClip, 0.7f);
                Result.SetActive(true);
                nextLv.SetActive(true);
                Invoke("TimeStop", 2f);
                Time.timeScale = 0;

                if (level == 3)
                {                  
                    nextLv.SetActive(false);
                }
                
                if (level <= toplevel)
                {
                    if (saveLevel <= toplevel)
                    {
                        saveLevel = toplevel;
                        GameLvSave();
                    }
                    if (saveLevel == 3)
                    {
                        hiddenLv = 1;
                    }
                }
            }
        }
        else
        {
            firstTry.anim.SetTrigger("isClose");
            secondTry.anim.SetTrigger("isClose");
        }
    }

    private void TimeStop()
    {
        Time.timeScale = 0.0f;
    }

    private static void LoadChoiceScene()
    {
        SceneManager.LoadScene("ChoiceScene");
    }

    public void GameLvSave()
    {
        PlayerPrefs.SetInt("GameLv", toplevel);
        PlayerPrefs.Save();
    }
    IEnumerator GraduallyIncreasePitch(float targetPitch, float duration)
    {
        float startPitch = audioManager.audioSource.pitch;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            audioManager.audioSource.pitch = Mathf.Lerp(startPitch, targetPitch, elapsed / duration);
            yield return null;
        }
    }
    public void UpdateCardBackImages()
    {   
        Card[] cards = FindObjectsOfType<Card>();
        foreach (Card card in cards)
        {
            card.Setting(card.idx);
        }
    }

    Scene GetCurrentScene()
    {
        return SceneManager.GetActiveScene(); 
    }
}
