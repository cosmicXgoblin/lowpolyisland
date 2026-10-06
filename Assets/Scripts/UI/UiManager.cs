using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;


public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject QuestBoard;
    [SerializeField] private TextMeshProUGUI QuestText;

    [SerializeField] private GameObject DialogueManager;
    [SerializeField] private GameObject DialogueTrigger;

    [SerializeField] private GameObject Player;
    private string nameQuestboard;
    public bool tutorialDone;      // give an option later
    private bool ok = false;
    public GameObject OkButton;

    [SerializeField] private GameObject PigeonTrigger;
    [SerializeField] private GameObject Slot1;



    private void Awake()
    {
        nameQuestboard = "tutorial";
        tutorialDone = false; // change it in the menu
    }
    void Start()
    {
        OkButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // this is much and very spaghetti-ish. I am sorry for that, i was sick a lot and now i
        // ... don't have the time to sort it through
        // Due to the dialoge there are a lot of conditions, especially when it comes to showing the 
        // ... visual Cue, the tutorial / questlog or the pigeon in general.
        if (PigeonTrigger.GetComponent<DialogueTrigger>().playerInRange
            && !PigeonTrigger.GetComponent<DialogueTrigger>().dialog150
            && tutorialDone
            && !Slot1.activeInHierarchy)
            showTip();
        else if (!PigeonTrigger.GetComponent<DialogueTrigger>().playerInRange)
        {
            ClearBoard();
            if
            (!tutorialDone)
            {
                setTutorial(nameQuestboard);
                //ClampRotation(); // not in use atm, sadly i didnt have the time for it
                OkButton.SetActive(true);
            }
            else if (tutorialDone)
            {
                OkButton.SetActive(false);
                // DeclampRotation();
                // Debug.Log("Tutorial is done.");
                ok = false;
            }
        }
    }

    // the tutorial for the beginning
    public void setTutorial(string name)
    {
        // Debug.Log("Ok is " + ok);
        // Debug.Log("Quest ist " + nameQuestboard);

        if (name == "tutorial" && !ok)
        {
            QuestText.text = "Welcome to low poly island!";
            OkButton.SetActive(true);
        }
        else if (name == "tutorial" && ok)
        {
            nameQuestboard = "tutorial1";
            ok = false;
        }
        else if (name == "tutorial1" && !ok) QuestText.text = "You can move with WASD";
        else if (name == "tutorial1" && ok)
        {
            nameQuestboard = "tutorial2";
            ok = false;
        }
        else if (name == "tutorial2" && !ok) QuestText.text = "The Water is deadly. Do not try to swim please. Jump with SPACE.";
        else if (name == "tutorial2" && ok)
        {
            nameQuestboard = "tutorial3";
            ok = false;
        }
        else if (name == "tutorial3" && !ok) QuestText.text = "Picking things up is easy, just press E. But there is nothing to pick up now.";
        else if (name == "tutorial3" && ok)
        {
            nameQuestboard = "tutorial4";
            ok = false;
        }
        else if (name == "tutorial4" && !ok) QuestText.text = "Please do not fall of the plattforms. You would fall endlessly.";
        else if (name == "tutorial4" && ok)
        {
            nameQuestboard = "tutorial5";
            ok = false;
        }
        else if (name == "tutorial5" && !ok) QuestText.text = "Also, you can run with SHIFT.";
        else if (name == "tutorial5" && ok)
        {
            nameQuestboard = "tutorial6";
            ok = false;
        }
        else if (name == "tutorial6" && !ok)
        {
            QuestText.text = "Let's begin your short adventure. Talk to the pigeon when you are ready!";
            tutorialDone = true;
        }
        else if (name == "tutorial6" && ok)
        {
            nameQuestboard = "tutorial7";
            ok = false;
        }
        else if (name == "tutorial7")
        {
            tutorialDone = true;
            Debug.Log(tutorialDone);
        }
    }
        // leaving this here for myself bc i wanted to redo it
        //public void setTutorial(string name)
        //{
        //if (name == "tutorial")
        //{
        //    for (int i = 0; i <= 4; i++)
        //    {
        //        if (i == 0)
        //        {
        //            QuestText.text = "Welcome to low poly island! You can move with WASD";
        //        }
        //        if (i == 1 && ok)
        //        {
        //            QuestText.text = "The Water is deadly. Do not try to swim please. Jump with SPACE.";
        //        }
        //        if (i == 2 && ok)
        //        {
        //            QuestText.text = "Picking things up is easy, just press E. But there is nothing to pick up now.";
        //            ok = false;
        //        }
        //        if (i == 3 && ok)
        //        {
        //            QuestText.text = "Please do not fall of the plattforms. You would fall endlessly.";
        //            ok = false;
        //        }
        //        if (i == 4 && ok)
        //        {
        //            QuestText.text = "Let's begin your short adventure. Talk to the pigeon when you are ready!";
        //            ok = false;
        //        }
        //    }
        //}
        //}

    public void setQuestboard(string name)
    {
        if (name == "dialog075" ) QuestText.text = "Tip: Talk to the pigeon again.";
        else if (name == "dialog1" ) QuestText.text = "Tip: Talk to the pigeon again.";
        else if (name == "dialog150") QuestText.text = "Quest: 'The Die'";
        else if (name == "dialog200") QuestText.text = "Tip: Investigate the Tree.";
        else if (name == "dialog250") QuestText.text = "Quest: 'The Coin'";
        else if (name == "dialog250") QuestText.text = "Tip: Talk to the pigeon again.";
        //else if (name != "tutorial") QuestText.text = "ERROR 404. Somethings seems to be wrong. This is not a drill.";
    }

    public void showTip()
    {
        QuestText.text = "Press [E] to talk to someone or something.";
    }

    public void okClicked()
    {
        ok = true;
        // Debug.Log("You clicked 'Ok'.");
    }
    public void ClearBoard()
    {
        QuestText.text = " ";
    }
}
