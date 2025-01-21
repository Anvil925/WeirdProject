using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 버튼 컴포넌트를 사용하기 위해 필요

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // 버튼 연결
    public Button loadSceneButton;

    private void Start()
    {
        // 버튼 클릭 이벤트 등록
        loadSceneButton.onClick.AddListener(LoadNextLevel);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");
        // Wait
        yield return new WaitForSeconds(transitionTime);
        // Load scene
        SceneManager.LoadScene(levelIndex);
    }
}