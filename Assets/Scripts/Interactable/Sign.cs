using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : InteractableObject
{
    public override void OnInteract()
    {
        FindObjectOfType<HistoryManager>().DisableButton();
        FindObjectOfType<HistoryManager>().animationIsPlaying = true;
        StartCoroutine("Reading");
        _dialogue.TriggerDialogue();
    }
}
