using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoryManager : MonoBehaviour
{
    [SerializeField] private GameObject island;
    [SerializeField] private GameObject[] invisibleWall = new GameObject[2];
    public bool atackEnabled;
    public bool animationIsPlaying;
    public bool radarEnabled;
    public int puzzleStones;
    public bool keyEnabled;
    public GameObject iButton;
    public int coin;
    private void Update()
    {
        CheckGameProgression();
        #region Android UI Managment
        //Android UI
        if (FindObjectOfType<DialogueManager>().onDialogue)
        {
            DisableButton();
        }
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            FindObjectOfType<DontDestroy>().On();
            SceneManager.LoadScene(3);
        }*/
    }

    

    public void EnableButton()
    {
        iButton.SetActive(true);
    }
    public void DisableButton()
    {
        iButton.SetActive(false);
    }
    #endregion
    private void CheckStonesPuzzle()
    {
        if (puzzleStones >= 3)
        {
            Destroy(invisibleWall[1]);
            island.SetActive(true);
        }
    }
    private void CheckAttack()
    {
        if (atackEnabled)
        {
            Destroy(invisibleWall[0]);
        }
    }
    private void CheckGameProgression()
    {
        CheckStonesPuzzle();
        CheckAttack();
    }
}
