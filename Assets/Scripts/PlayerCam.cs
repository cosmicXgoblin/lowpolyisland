using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Sensitivity for the Axes")]
    public float sensX;
    public float sensY;

    [Header("Rotation of the Camera")]
    float xRotation;
    float yRotation;

    [Header("Other")]
    public Transform orientation;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject UiManagement;

    private void Start()
    {
        // cursor is confined to the screen and also invisible
        Cursor.lockState = CursorLockMode.Confined; 
        //Cursor.visible = false;
    }


    private void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            // making sure you are not able to move your camera while talking
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);
            Cursor.visible = true;
            // so we can see what we are clicking at
            return;
        }
        else if (UI.GetComponent<MenuManager>().pause == true)
        {
            Cursor.visible = true;
            // so we can see what we are clicking at
            return;
        }
        else if (UiManagement.GetComponent<UiManager>().tutorialDone == false)
        {
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);
            return;
        }

        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // unity is weird, thats how it handles rotations and inputs apparently?
        yRotation += mouseX;
        xRotation -= mouseY;

        // making sure you can't look up or down more than 90°
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate camera long both axis
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        // rotate player along y-axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
