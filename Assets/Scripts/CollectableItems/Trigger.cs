 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private bool playerInRange;

    [Header("Item")]
    [SerializeField] private GameObject Collectible;
    [SerializeField] private Sprite image;

    [Header("Collectible Slots")]
    [SerializeField] private GameObject Slot1;
    // [SerializeField] private GameObject Slot2;   not in use at the moment, but it would be expandable



    private void Awake()
    {
        // sets things to false so we don't have any false results
        playerInRange = false;
        visualCue.SetActive(false);
        Slot1.SetActive(false); 

        //Slot2.SetActive(false);   still not in use, but still expandable
    }

    private void Update()
    {
        if (playerInRange)
        // if the player (through comparing the tag) is in range, the visual clue will be set to active
        // ... if the player then presses the interactin-key, it will be added to the slot
        {
            visualCue.SetActive(true);
            // if (InputManager.GetInstance().GetInteractPressed)
            // for later with the new input system
            if (Input.GetKeyDown(KeyCode.E))
            {
                Add();
            }
        }
        else visualCue.SetActive(false);
    }

    // simple Collidercheck to check if the player is in range or not
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

    // if the slot the collectible should go into is not already active in hierarchy (aka used), it will add itself
    // ... to it. That means the image will change to it's image, the Slot will be activated and a sound will play.
    // ... Then the item in the wild wil be destroyed.
    public void Add()
    {
        if (Slot1.activeInHierarchy)
        { 
            Debug.Log("Slot 1 is active.");
        }
        else
        {
            Debug.Log("Slot 1 will be set as active.");
            Slot1.GetComponent<Image>().sprite = image;
            Slot1.SetActive(true);
            //if (!objectFound) objectFound = true;
            SoundEffectManager.Play("Pick-Up");
            Destroy(Collectible);
        }
        Debug.Log("The Collectable was added.");
    }
}

