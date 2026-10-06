using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEditor;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Quests")]
    [SerializeField] private GameObject Dice;
    [SerializeField] private GameObject Coin;

    [Header("NPCs")]
    [SerializeField] public GameObject Pigeon;
    [SerializeField] public GameObject Pigeon_Visual;
    [SerializeField] public GameObject Pigeon_VisualClue;

    [Header("Other")]
    [SerializeField] private GameObject UI;
    private Story currentStory;
    [SerializeField] public GameObject Player;
    public bool dialogueIsPlaying { get; private set; }
    private static DialogueManager instance;

    //[SerializeField] public GameObject PlayerOrientation;
    // public bool because we want to access it elswhere (to stop the player from moving around while talking)
    // and get; private set; so it is read only for other scripts


    private void Awake()
    {
        if (instance != null) Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        instance = this;

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        Dice.SetActive(false);
        Coin.SetActive(false);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        // for every gameobject choice we are accessing one of the choicetextes
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying) return;
        // if there are not current choices and we leftlick, we continue our story
        if (currentStory.currentChoices.Count == 0 && (Input.GetMouseButtonDown(0))) 
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        //Player.GetComponent<PlayerMovement>().CheckOrientation();
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        // this is inky specific:
        // ... we bind (and later unbind) these functions so we can access them via inky
        // ... i think it's down to personal preference how you organize this, i wanted to differentiate between 3 things:
        // ... - startQuest (for things that will change bigger things and are more questlike)
        // ... - changeDialogue (for a simple dialogueChange)
        // ... - and other (for, you guessed it, other stuff like the game over screen)
        currentStory.BindExternalFunction("startQuest", (string questName) =>
        {
            if (questName == "The Die")
            {
                Pigeon.GetComponent<DialogueTrigger>().dialog1 = false;
                Pigeon.GetComponent<DialogueTrigger>().dialog075 = false;
                Pigeon.GetComponent<DialogueTrigger>().dialog150 = true;

                Dice.SetActive(true);
                Debug.Log("You've got the quest: " + questName);

                ExitDialogueMode();
            }
            // in this quest, the pigeon is in the tree and behaves like it is the tree - that's why we are transforming
            // ... its position and allt he other stuff
            if (questName == "the Tree talks")
            {
                Debug.Log(questName);
                Pigeon.GetComponent<DialogueTrigger>().dialog150 = false;
                Pigeon.transform.position = Pigeon.transform.position - new Vector3(-10.55f, -1.99f, -10.61f);
                Pigeon_VisualClue.transform.position = Pigeon_VisualClue.transform.position - new Vector3(-10.55f, -1.99f, -10.61f);
                Pigeon_Visual.SetActive(false);
                Pigeon.GetComponent<DialogueTrigger>().dialog2 = true;

            } 

            // here, the pigeon "comes back" after you talked to the "tree"
            if (questName == "the Coin")
            {
                Debug.Log(questName);
                Coin.SetActive(true);
                Pigeon.GetComponent<DialogueTrigger>().dialog2 = false;
                Pigeon.transform.position = Pigeon.transform.position + new Vector3(-10.55f, -1.99f, -10.61f);
                Pigeon_VisualClue.transform.position = Pigeon_VisualClue.transform.position + new Vector3(-10.55f, -1.99f, -10.61f);
                Pigeon.GetComponent<DialogueTrigger>().dialog250 = true;
                

                //Pigeon.GetComponent<DialogueTrigger>().dialog1 = false;
                // Pigeon.GetComponent<DialogueTrigger>().dialog075 = true; // change later to other function
            } // for the external functions
        });

        currentStory.BindExternalFunction("changeDialogue", (string newDialogue) =>
        {
            if (newDialogue == "quest1")
            {
    
                Pigeon.GetComponent<DialogueTrigger>().dialog0 = false;
                Pigeon.GetComponent<DialogueTrigger>().dialog1 = true;

                Debug.Log("A new dialogue is available." );

                ExitDialogueMode();
            }

            if (newDialogue == "sulking")
            {
                Debug.Log("A new dialogue is available.");
                Pigeon.GetComponent<DialogueTrigger>().dialog1 = false;
                Pigeon.GetComponent<DialogueTrigger>().dialog075 = true;
                ExitDialogueMode();
                //sulkingHoomin = true;
                //Debug.Log("sulkingHoomin is now set to " + sulkingHoomin);
            }
            //if (newDialogue == "foundObject1")
            //{
            //    Pigeon.GetComponent<DialogueTrigger>().dialog075 = false;
            //    Pigeon.GetComponent<DialogueTrigger>().dialog150 = true;
            //    //sulkingHoomin = true;
            //    //Debug.Log("sulkingHoomin is now set to " + sulkingHoomin);
            //}

            //EXTERNAL dialogue(sulkingHoomin)


            //ContinueStory();
        });
        
        currentStory.BindExternalFunction("other", (string name) =>
        {
            if (name == "gameOver")
            {
                UI.GetComponent<MenuManager>().gameOver();
                Debug.Log("GAME OVER");
            }
            if (name == "youWon")
            {
                Pigeon.gameObject.SetActive(false);
                Debug.Log("You won the game! Wow, much talent, very fun, 10/10.");
            }

        });

        // after that, wie continue our story
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        // unbinding the inky specific things
        currentStory.UnbindExternalFunction("startQuest");
        currentStory.UnbindExternalFunction("changeDialogue");
        currentStory.UnbindExternalFunction("other");

        // no dialogue is playing, so we don't need to see the dialogue panel and have no text
        dialoguePanel.SetActive(false);
        dialogueIsPlaying = false;
        dialogueText.text = "";
        //Player.GetComponent<PlayerMovement>().SetOrientation();
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // set text for the current dialogue line
            dialogueText.text = currentStory.Continue();
            // display choices, if any, for this dialogue line
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
            // Debug.Log("DialogueMode was exited");
        }
    }

    private void DisplayChoices()
    {
        // we create a list with our current choices
        List<Choice> currentChoices = currentStory.currentChoices;
        // check if our UI is able to support this many choices (defensive)
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }
        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
