using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using CnControls;

public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    public IDialogueTrigger _dialogue;
    private IInputHandler _input;
    public bool disable;
    private float distance;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        _dialogue = GetComponent<IDialogueTrigger>();
        _input = GetComponent<IInputHandler>();
    }
    private void Update()
    {
        Interact();
    }
    public virtual void Interact()
    {
        //Check if it's close
        distance = Vector3.Distance(this.transform.position, Player.transform.position);
        if (distance < 0.5 && FindObjectOfType<Player>().FacingDirection == "Y+" && !disable)
        {
            if (!FindObjectOfType<DialogueManager>().onDialogue && !disable)
            {
                FindObjectOfType<HistoryManager>().EnableButton();
            }
            if (_input.PressInteractButton() && !FindObjectOfType<DialogueManager>().onDialogue || CnInputManager.GetAxis("Jump") > 0 && !FindObjectOfType<DialogueManager>().onDialogue)
            {
                OnInteract();
            }
        }
        if (distance > 0.5 && distance < 0.6)
        {
            FindObjectOfType<HistoryManager>().DisableButton();
        }
    }
    public virtual void OnInteract()
    {
        FindObjectOfType<HistoryManager>().DisableButton();
        FindObjectOfType<HistoryManager>().animationIsPlaying = true;
        StartCoroutine("Reading");
        _dialogue.TriggerDialogue();
    }
    IEnumerator Reading()
    {
        disable = true;
        yield return new WaitForSeconds(0.7f);
        FindObjectOfType<HistoryManager>().animationIsPlaying = false;
        disable = false;
    }
    #region Android Old
    public void BI()
    {
        if (distance < 0.5 && !disable && gameObject.activeInHierarchy && FindObjectOfType<Player>().FacingDirection == "Y+" || distance < 0.5 && !disable && gameObject.activeInHierarchy && FindObjectOfType<Player>().FacingDirection == "X+Y+"|| distance < 0.5 && !disable && gameObject.activeInHierarchy && FindObjectOfType<Player>().FacingDirection == "X-Y+")
        {
            if (!FindObjectOfType<DialogueManager>().onDialogue )
            {
                if (gameObject.name.Equals("Door") && FindObjectOfType<HistoryManager>().keyEnabled)
                {
                    FindObjectOfType<DontDestroy>().On();
                    SceneManager.LoadScene(3);
                }
                FindObjectOfType<HistoryManager>().DisableButton();
                StartCoroutine("Reading");
                FindObjectOfType<HistoryManager>().animationIsPlaying = true;
                _dialogue.TriggerDialogue();
            }
        }
    }
    #endregion
}
