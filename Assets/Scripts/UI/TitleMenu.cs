using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] public GameObject TutorialQuestion;

    private void Awake()
    {
        TutorialQuestion.SetActive(false);
    }
    public void Test()
    {
        Debug.Log("Testing war erfolgrich brudi");
    }

    //public void LoadWithTutorial()
    //{
    //    SceneManager.LoadSceneAsync(1);
    //}

    //public void LoadWithoutTutorial()
    //{
    //    SceneManager.LoadSceneAsync(1);
    //}

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
