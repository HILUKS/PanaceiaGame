using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractableObject
{
    public override void OnInteract()
    {
        if (gameObject.name.Equals("Door") && FindObjectOfType<HistoryManager>().keyEnabled)
        {
            FindObjectOfType<DontDestroy>().On();
            SceneManager.LoadScene(2);
            FindObjectOfType<HistoryManager>().keyEnabled = false;
            FindObjectOfType<HistoryManager>().DisableButton();
        }
        FindObjectOfType<HistoryManager>().DisableButton();
        FindObjectOfType<HistoryManager>().animationIsPlaying = true;
        StartCoroutine("Reading");
        _dialogue.TriggerDialogue();
    }
}
