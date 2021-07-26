using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarAction : MonoBehaviour, IRadarAction
{
    [SerializeField] private GameObject treasureKey;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject coin;
    //Verify Wrong button
    private string DetermineWinner(string objtag)
    {
        if (objtag.Equals("RButton"))
        {
            return "SButton";
        }
        else if (objtag.Equals("PButton"))
        {
            return "RButton";
        }
        else
        {
            return "PButton";
        }
    }
    //Do the Result
    public virtual void ActionResult(string objtag, string buttonused, GameObject button)
    {
        if (objtag.Equals(buttonused))
        {
            Correct(button);
        }
        else if(buttonused.Equals(DetermineWinner(objtag)) )
        {
            Wrong(button, monster);
        }
        else{
            Refresh(button);
        }
    }
    public void Correct(GameObject button)
    {
        if (FindObjectOfType<Radar>().treasureBox.transform.tag.Equals("TreasureKey"))
        {
            Instantiate(treasureKey, transform.position, transform.rotation);
            FindObjectOfType<Player>().DestroyRadar();
            FindObjectOfType<Radar>().DestroyTreasureBox();
            Destroy(button);
        }
        else
        if (FindObjectOfType<Radar>().treasureBox.transform.tag.Equals("TreasureBox"))
        {
            Instantiate(coin, transform.position, transform.rotation);
            FindObjectOfType<Player>().DestroyRadar();
            FindObjectOfType<Radar>().DestroyTreasureBox();
            Destroy(button);
        }
    }
    public void Wrong(GameObject button, GameObject monster)
    {
        if (FindObjectOfType<Radar>().treasureBox.transform.tag.Equals("TreasureBox"))
        {
            Instantiate(monster, transform.position, transform.rotation);
            FindObjectOfType<Player>().DestroyRadar();
            FindObjectOfType<Radar>().DestroyTreasureBox();
            Destroy(button);
        }
        else
                    if (FindObjectOfType<Radar>().treasureBox.transform.tag.Equals("TreasureKey"))
        {
            FindObjectOfType<RadarButtonPuzzle>().InstantiatePuzzle();
            Destroy(button);
        }
    }
    public void Refresh(GameObject button)
    {
        FindObjectOfType<RadarButtonPuzzle>().InstantiatePuzzle();
        Destroy(button);
    }

}
