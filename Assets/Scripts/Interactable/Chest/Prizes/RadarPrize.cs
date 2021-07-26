using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPrize : MonoBehaviour, IPrize
{
    public bool PrizeItsNew()
    {
        return !FindObjectOfType<HistoryManager>().radarEnabled;
    }
    public void GiveThePrize()
    {
        FindObjectOfType<HistoryManager>().radarEnabled = true;
    }
}
