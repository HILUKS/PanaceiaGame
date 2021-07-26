using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] objs = new GameObject[3];
   
    public void On()
    {
        for (int i = 0; i < 5; i++)
        {
            DontDestroyOnLoad(objs[i]);
        }
    }
}
