using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// i needed this script for making the dialogue choices with the keyboard, but now it's not in use anymore
// ... but if i want to implement it again, i already have it
public class AutoReselector : MonoBehaviour
{ 

    [SerializeField] private EventSystem eventSystem;
    //[SerializeField] private GameObject dialoguePanel;
    private GameObject lastSelectedObject;


    void Awake()
    {
        if (eventSystem == null)
            eventSystem = gameObject.GetComponent<EventSystem>();
      //    dialoguePanel.SetActive(true);

    }

    void Update()
    {
        if (eventSystem.currentSelectedGameObject == null)
            eventSystem.SetSelectedGameObject(lastSelectedObject); // no current selection, go back to last selected
        else
            lastSelectedObject = eventSystem.currentSelectedGameObject; // keep setting current selected object
    }
}


