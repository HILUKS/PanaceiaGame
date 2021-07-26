using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletable : MonoBehaviour
{
    [SerializeField] public GameObject SFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Collect();
        }

    }
    public virtual void Collect()
    {
        
    }
}