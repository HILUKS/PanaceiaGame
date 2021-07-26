using UnityEngine;

class RPSPrize : MonoBehaviour, IPrize
{
    public bool PrizeItsNew()
    {
        return !FindObjectOfType<HistoryManager>().atackEnabled;
    }
    public void GiveThePrize()
    {
        FindObjectOfType<HistoryManager>().atackEnabled = true;
    }
}