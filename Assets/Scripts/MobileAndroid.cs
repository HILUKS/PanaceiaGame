using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileAndroid : MonoBehaviour
{
    public bool radar;
    public bool atack;
    public bool key;
    public bool BL;
    public GameObject radP;
    public GameObject anyB;
    public GameObject treasure;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (radar)
        {
           // radP = FindObjectOfType<Radar>().gameObject;
        }
        if (treasure)
        {
            //treasure = FindObjectOfType<Thest>().gameObject;
        }
        if (atack)
        {
            //anyB = FindObjectOfType<AnyButton>().gameObject;
        }

        
        
    }
    public void Rad()
    {
        if (radP != null)
        {
            //   radP.GetComponent<Radar>().AndroidDestroyRadar();
        }



    }
    public void R()
    {
        if (anyB != null)
        {
            //anyB.GetComponent<AnyButton>().prock = true;
        }
    }
    public void P()
    {
        if (anyB != null)
        {
            //anyB.GetComponent<AnyButton>().ppaper = true;
        }
    }
    public void S()
    {
        if (anyB != null)
        {
            //anyB.GetComponent<AnyButton>().pscissor = true;
        }
    }
    public void TreasureChest()
    {

        if (treasure != null)
        {
            //treasure.GetComponent<Thest>().BI();
        }
    }
}
