using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CnControls;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public bool onDialogue;
    public bool endedWriting;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && onDialogue && endedWriting || Input.GetKeyDown(KeyCode.JoystickButton0) && onDialogue && endedWriting || CnInputManager.GetAxis("Jump") > 0 && onDialogue && endedWriting)
        {
            this.GetComponent<AudioSource>().Play();
            endedWriting = false;
            DisplayNextSentence();
        }
    }
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopCoroutine("TypeSentence");
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        endedWriting = true;
        onDialogue = true;
    }
    public void EndDialogue()
    {
        StartCoroutine("EndingCoroutine");
    }
    IEnumerator EndingCoroutine()
    {
        animator.SetBool("IsOpen", false);
        yield return new WaitForSeconds(0.2f);
        onDialogue = false;
        StopCoroutine("EndingCoroutine");
       
    }
    public void BI()
    {
        if ( onDialogue && endedWriting )
        {
            endedWriting = false;
            DisplayNextSentence();
        }
    }
}
