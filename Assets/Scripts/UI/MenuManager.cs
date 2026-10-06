using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Pause Menu")]
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject Achievements;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Exit;
    public bool pause = false;

    [Header("Options Menu")]
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject backToPauseButton;

    [Header("Game Over")]
    [SerializeField] private GameObject GameOverScreen1;
    [SerializeField] private GameObject GameOverScreen2;
    [SerializeField] private GameObject DialoguePanel;

    private void Awake()
    {
        // setting everything to false so it does not hinder our sight 
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(false);
        GameOverScreen1.SetActive(false);
        GameOverScreen2.SetActive(false);
    }

    void Update()
    {
        // if we pres P and the bool pause is not true; it will set the game to pause.
        // ... that means the bool will be set to true and we can see the pause menu now.
        // ... if it was already true, we will call the function backToGame().
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pause)
            {
                PausePanel.gameObject.SetActive(true);
                pause = true;
                // Debug.Log("Pausenmenü wird geöffent");
            }
            else
            {
                backToGame();
            }
        }

        // this is for the gameOver-screen:
        // ... if we are on the first screen and left click, it will show us the second screen
        // ... and deactivate the first one. yey.
        if (Input.GetMouseButtonDown(0) && GameOverScreen1.activeInHierarchy)
        {
            GameOverScreen1.SetActive(false);
            GameOverScreen2.SetActive(true);
        }
           
    }

    // it will deactivate the pause menu and unpause the game
    public void backToGame()
    {
        PausePanel.gameObject.SetActive(false);
        pause = false;
        //b Debug.Log("Pausenmenü wird geschlossen");
    }

    public void openAchievements()
    {
        Debug.Log("You clicked 'Achievements'. This is currently not available");
    }

    // will activate the options and deactivate the pause menu
    public void openOptions()
    {
        OptionsPanel.SetActive(true);
        PausePanel.SetActive(false);
        // Debug.Log("You clicked 'Options'.");
    }

    public void exitGame()
    {
        Debug.Log("You clicked 'exit'. This is currently not available");
    }

    public void backToPause()
    {
        OptionsPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void gameOver()
    {
        //Debug.Log("You clicked 'exit'. This is currently not available");
        pause = true;
        DialoguePanel.SetActive(false);
        GameOverScreen1.SetActive(true);
    }




}
