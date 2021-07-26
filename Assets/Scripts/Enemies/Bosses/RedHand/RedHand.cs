using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RedHand : MonoBehaviour
{

    [SerializeField] private GameObject sl;
    [SerializeField] private float speed = 1.0F;
    [SerializeField] private IRedHandAttack _attack;
    private float distance;
    private bool stop;
    private void Awake()
    {
        _attack = GetComponent<IRedHandAttack>();
    }
    void Update()
    {
        Move();
        _attack.Attack();
    }
    
    private void Move()
    {
        distance = Vector3.Distance(sl.transform.position, FindObjectOfType<Player>().transform.position);
        if (!stop)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(FindObjectOfType<Player>().transform.position.x, FindObjectOfType<Player>().transform.position.y + 0.5f, FindObjectOfType<Player>().transform.position.z), 5 * Time.deltaTime);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<Player>().Damage();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Paper")
        {
            StartCoroutine("Blink");
        }
    }
    IEnumerator Blink()
    {
        //audioSource.PlayOneShot(clip1, 1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        StopCoroutine("Blink");
    }
}
