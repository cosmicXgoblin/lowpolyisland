using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual  Cue")]
    [SerializeField] private GameObject visualCue;
    public bool playerInRange;
    public bool noVisualCue;

    [Header("NPC")]
    [SerializeField] private GameObject PigeonOnTent;
    [SerializeField] private GameObject PigeonOnTent_Visual;

    [Header("Slots")]
    [SerializeField] public GameObject Slot1;
    //[SerializeField] public GameObject Slot2; still not in use, still expendable

    [Header("Ink JSON")]
    [SerializeField] private TextAsset dialogue0;
    [SerializeField] private TextAsset dialogue075;
    [SerializeField] private TextAsset dialogue1;
    [SerializeField] private TextAsset dialogue150;
    [SerializeField] private TextAsset dialogue2;
    [SerializeField] private TextAsset dialogue250;

    [Header("booleans dialogues")]
    public bool dialog0 = true;
    public bool dialog075 = false;
    public bool dialog1 = false;
    public bool dialog150 = false;
    public bool foundDie = false;
    public bool dialog2= false;
    public bool foundCoin = false;
    public bool dialog250 = false;

    [Header("UI")]
    [SerializeField] private GameObject UiManager;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject GameOverScreen2;
    [SerializeField] private bool gameOver;

    [Header("Environment")]
    [SerializeField] private GameObject SakuraBlossomsHalf;
    [SerializeField] private GameObject SakuraBlossomsFull;
    [SerializeField] private bool sakuraHalf;
    [SerializeField] private bool sakuraFull;

    private void Awake()
    {
        // looks if the player is in range
        playerInRange = false;
        // set the visual cue to inactiv by the start of the game
        visualCue.SetActive(false);
        noVisualCue = false;

        SakuraBlossomsHalf.SetActive(false);
        SakuraBlossomsFull.SetActive(false);
    }

    private void Update()
    {
        // as long as we didn't find a item and the dialog for finding the item is the next
        // one, the pigeon will not be active
        if (gameOver == true && !GameOverScreen2.activeInHierarchy)
        {
            UI.GetComponent<MenuManager>().gameOver();
            return;
            // Debug.Log("Yep, Game over for testing purpose. Nothing to see here.");
        }

        if (dialog150 && !playerInRange)
        {
            UiManager.GetComponent<UiManager>().setQuestboard("dialog150");
            if (!Slot1.activeInHierarchy || !foundDie)
            {
                Debug.Log("First option is active");
                PigeonOnTent_Visual.SetActive(false);
                visualCue.SetActive(false);
                noVisualCue = true;
                Debug.Log("The Pigeon is nowhere to be seen.");
            }
            if (Slot1.activeInHierarchy || foundDie)
            {
                Debug.Log("Second option is active");
                //itemFound = true;
                PigeonOnTent_Visual.SetActive(true);
                noVisualCue = false;
                visualCue.SetActive(true);
                Debug.Log("The Pigeon is now back on the tent");
                foundDie = true;
            }
        }

        if (dialog2) SakuraBlossomsHalf.SetActive(true);

        if (dialog250 && !playerInRange)
        {
            UiManager.GetComponent<UiManager>().setQuestboard("dialog250");

            if (!Slot1.activeInHierarchy || !foundCoin)
            {
                Debug.Log("First option is active");
                PigeonOnTent_Visual.SetActive(false);
                visualCue.SetActive(false);
                noVisualCue = true;
                Debug.Log("The Pigeon is nowhere to be seen.");
            }
            if (Slot1.activeInHierarchy || foundCoin)
            {
                Debug.Log("Second option is active");
                //itemFound = true;
                PigeonOnTent_Visual.SetActive(true);
                noVisualCue = false;
                foundCoin = true;
                visualCue.SetActive(true);
                Debug.Log("The Pigeon is now back on the tent");
                SakuraBlossomsFull.SetActive(true);
            }
        }

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && !noVisualCue)
        {
            visualCue.SetActive(true);
            // if (InputManager.GetInstance().GetInteractPressed)
            // for later with the new input system
            // mach doch ein dictionary junge was stimmt nicht mit diiiir
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (dialog0)
                    DialogueManager.GetInstance().EnterDialogueMode(dialogue0);
                //if (dialog075)
                //    DialogueManager.GetInstance().EnterDialogueMode(dialogue075);
                if (dialog075)
                    DialogueManager.GetInstance().EnterDialogueMode(dialogue075);
                if (dialog1)
                    DialogueManager.GetInstance().EnterDialogueMode(dialogue1);
                if (Slot1.activeInHierarchy && dialog150)
                {
                    PigeonOnTent.SetActive(true);
                    DialogueManager.GetInstance().EnterDialogueMode(dialogue150);
                    Slot1.SetActive(false);
                    foundDie = false;
                }
                if (dialog2)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogue2);
                    //foundDie = false;
                }
                if (dialog250)
                   DialogueManager.GetInstance().EnterDialogueMode(dialogue250);
            }
                    }
        else visualCue.SetActive(false);

        if (sakuraHalf) SakuraBlossomsHalf.SetActive(true);
        if (sakuraFull)
        {
            SakuraBlossomsHalf.SetActive(false);
            SakuraBlossomsFull.SetActive(true);
        }
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
