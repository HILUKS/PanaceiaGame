using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ATK : MonoBehaviour
{
    [SerializeField] private IATKDirection _atkDirection;
    [SerializeField] private IATKMovement _atkMovement;
    public GameObject[] gfx = new GameObject[3];
    void Awake()
    {
        _atkDirection = GetComponent<IATKDirection>();
        _atkMovement = GetComponent<IATKMovement>();
       _atkDirection.AtkDirection();
    }

    void Update()
    {
        _atkMovement.AtkMovement();
    }
    
    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "TreasureBox" && collision.gameObject.tag != "Coin"&& collision.gameObject.tag != "Heart" && collision.gameObject.tag != "TreasureKey" && collision.gameObject.tag != "col")
        {
            InstantiateParticleAndDestroy();
        }
    }

    private void InstantiateParticleAndDestroy()
    {
        if (gameObject.tag.Equals("Rock"))
        {
            Destroy(Instantiate(gfx[0], transform.position, transform.rotation), 0.4f);
        }
        if (gameObject.tag.Equals("Paper"))
        {
            Destroy(Instantiate(gfx[1], transform.position, transform.rotation), 0.4f);
        }
        if (gameObject.tag.Equals("Scissor"))
        {
            Destroy(Instantiate(gfx[2], transform.position, transform.rotation), 0.4f);
        }
        Destroy(gameObject);
    }
    #endregion
}
