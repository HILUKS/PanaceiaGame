using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPrize : MonoBehaviour, IPrize
{
    public bool PrizeItsNew()
    {
        return !FindObjectOfType<HistoryManager>().keyEnabled;
    }
    public void GiveThePrize()
    {
        FindObjectOfType<HistoryManager>().keyEnabled = true;
    }
}
