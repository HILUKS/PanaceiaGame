using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject prize;
    private Animator treasureAnimator;
    private IInputHandler _input;
    private IPrize _prize;
    private IDialogueTrigger _dialogue;
    private GameObject Player;
    private Animator chestAnimator;
    private bool opened;
    private float distance;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        treasureAnimator = prize.GetComponent<Animator>();
        chestAnimator = GetComponent<Animator>();
        _input = GetComponent<IInputHandler>();
        _prize = prize.GetComponent<IPrize>();
        _dialogue = GetComponent<IDialogueTrigger>();
    }
    private void Update()
    {
        distance = Vector3.Distance(this.transform.position, Player.transform.position);
        //Open Chest
        OpenChest();
    }
    private void OpenChest()
    {
        if (distance < 0.5 && FindObjectOfType<Player>().FacingDirection == "Y+")
        {
            //Check if the chest it's alredy opened
            if (!opened)
            {
                FindObjectOfType<HistoryManager>().EnableButton();
            }
            if (_input.PressInteractButton() && !FindObjectOfType<DialogueManager>().onDialogue && !opened || CnInputManager.GetAxis("Jump") > 0 && !FindObjectOfType<DialogueManager>().onDialogue && !opened)
            {
                //Checks if it's alredy recompensed
                if (_prize.PrizeItsNew())
                {
                    FindObjectOfType<HistoryManager>().DisableButton();
                    opened = true;
                    FindObjectOfType<HistoryManager>().animationIsPlaying = true;
                    chestAnimator.SetBool("Open", true);
                    StartCoroutine("OpenCoroutine");
                }
            }
        }
        if (distance > 0.5 && distance < 0.6)
        {
            FindObjectOfType<HistoryManager>().DisableButton();
        }
    }
    IEnumerator OpenCoroutine()
    {
        yield return new WaitForSeconds(0.65f);
        treasureAnimator.SetBool("IsOpen", true);
        yield return new WaitForSeconds(1f);
        _prize.GiveThePrize();
        _dialogue.TriggerDialogue();
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<HistoryManager>().animationIsPlaying = false;
        Destroy(prize);
        StopCoroutine("OpenCourotine");
    }
    #region Android Old System
    public void BI()
    {
        if (distance < 0.5 && gameObject.activeInHierarchy && FindObjectOfType<Player>().FacingDirection =="Y+" || distance < 0.5 && gameObject.activeInHierarchy && FindObjectOfType<Player>().FacingDirection == "X+Y+" || distance < 0.5 && gameObject.activeInHierarchy && FindObjectOfType<Player>().FacingDirection == "X-Y+")
        {
            if (!opened)
            {
                FindObjectOfType<HistoryManager>().EnableButton();
            }
            if (!FindObjectOfType<DialogueManager>().onDialogue && !opened )
            {
                if (transform.name.Equals("RPSChest") && !FindObjectOfType<HistoryManager>().atackEnabled)
                {
                    FindObjectOfType<HistoryManager>().DisableButton();
                    opened = true;
                    FindObjectOfType<HistoryManager>().animationIsPlaying = true;
                    chestAnimator.SetBool("Open", true);
                    StartCoroutine("OpenCoroutine");

                }
                if (transform.name.Equals("RadarChest") && !FindObjectOfType<HistoryManager>().radarEnabled)
                {
                    FindObjectOfType<HistoryManager>().DisableButton();
                    opened = true;
                    FindObjectOfType<HistoryManager>().animationIsPlaying = true;
                    chestAnimator.SetBool("Open", true);
                    StartCoroutine("OpenCoroutine");
                }
                if (transform.tag.Equals("KeyChest") && !FindObjectOfType<HistoryManager>().keyEnabled)
                {
                    FindObjectOfType<HistoryManager>().DisableButton();
                    opened = true;
                    FindObjectOfType<HistoryManager>().animationIsPlaying = true;
                    chestAnimator.SetBool("Open", true);
                    StartCoroutine("OpenCoroutine");
                }
            }
        }
    }
    #endregion
}
