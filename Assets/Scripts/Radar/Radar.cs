using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    
    private IRadarMovement _radarMovement;
    private IInputHandler _inputHandler;
    private IRadarPuzzle _radarpuzzle;
    [SerializeField] private GameObject hole;
    public GameObject theButton;
    public GameObject treasureBox;
    
    public bool staying;
    void Awake()
    {
        FindObjectOfType<HistoryManager>().atackEnabled = false;
        _radarMovement = GetComponent<IRadarMovement>();
        _inputHandler = GetComponent<IInputHandler>();
        _radarpuzzle = GetComponent<IRadarPuzzle>();
    }
    void Update()
    {
        _radarMovement.RadarPosition();
        if (FoundSomething())
        {
            _radarpuzzle.InstantiatePuzzle();
        }

        //Input
        if (_inputHandler.PressRadarButton())
        {
            FindObjectOfType<HistoryManager>().atackEnabled = true;
            FindObjectOfType<Player>().DestroyRadar();
        }
    }
    //Found Something
    private bool FoundSomething()
    {
        return staying && theButton == null;
    }
    #region Collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TreasureBox" )
        {
            treasureBox = collision.gameObject;
            _radarpuzzle.InstantiatePuzzle();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.tag == "TreasureBox" || collision.tag == "TreasureKey")
        {
            staying = true;
            treasureBox = collision.gameObject;
        }
        if (collision.tag != "TreasureBox" && collision.tag != "TreasureKey")
        {
            staying = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("TreasureBox") || collision.tag.Equals("TreasureKey"))
        {
            staying = false;
        }
        if ( theButton != null && !staying)
        {
            Destroy(theButton);
        }
    }
    #endregion
    //Local Destroying
    public void DestroyTreasureBox()
    {
        Instantiate(hole, transform.position, transform.rotation);
        Destroy(treasureBox);
    }
   
    //Destroyng Radar on Android
    private void AndroidDestroyRadar()
    {
        if (!FindObjectOfType<Player>().attacking && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying )
        {
            FindObjectOfType<MobileAndroid>().radar=false;
            FindObjectOfType<HistoryManager>().atackEnabled = true;
            FindObjectOfType<Player>().DestroyRadar();
        }
    }

}
