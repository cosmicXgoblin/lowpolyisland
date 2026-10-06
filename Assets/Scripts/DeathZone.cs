using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// very simple: if you touch it, you're death :)
public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            UI.GetComponent<MenuManager>().gameOver();
            Debug.Log("Congratulations! You are dying now.");
        }
    }
}
