using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    [SerializeField] private GameObject[] collectables = new GameObject[2];
    private Animator animator;
    private GameObject Player;
    private int rv;
    private float timeLeft;
    private float speed;
    private float distance;
    private float delay = 2f;
    private bool ImRock;
    private bool ImPaper;
    private bool ImScissor;
    private bool stop;
    private void Awake()
    {
        speed = 1f;
        animator = GetComponent<Animator>();
        timeLeft = Random.value * 10;
        rv = (int)(Random.value * 8);
        Player = GameObject.FindGameObjectWithTag("Player");
        //Define type
        GetMyType();
    }
    private void Update()
    {
        #region Walk
        //Walk
        Walk();
        #endregion
        #region Attack
        //Assault
        if (distance < 4 && !stop && distance > 1 && !animator.GetBool("Attack"))
        {
            Assault();
        }
        //Attack
        if (distance <= 1 && !stop)
        {
            StartCoroutine("Attack");
        }
        #endregion
    }
    private void GetMyType()
    {
        if (this.gameObject.tag == "REnemy")
        {
            ImRock = true;
        }
        else if (this.gameObject.tag == "PEnemy")
        {
            ImPaper = true;
        }
        else
        {
            ImScissor = true;
        }
    }
    private void Walk()
    {
        distance = Vector3.Distance(this.transform.position, Player.transform.position);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && !animator.GetBool("Attack"))
        {
            animator.speed = 0.3f;
            StartCoroutine("WalkingCoroutine");
        }
        else
        {
            if (distance > 4 && !animator.GetBool("Attack"))
            {
                animator.speed = 0.7f;
                switch (rv)
                {
                    case 0:
                        transform.Translate(-speed * Time.deltaTime, 0, 0);
                        this.GetComponent<SpriteRenderer>().flipX = true;
                        break;
                    case 1:
                        transform.Translate(-speed * Time.deltaTime, speed * Time.deltaTime, 0);
                        this.GetComponent<SpriteRenderer>().flipX = true;
                        break;
                    case 2:
                        transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                        this.GetComponent<SpriteRenderer>().flipX = true;
                        break;
                    case 3:
                        transform.Translate(speed * Time.deltaTime, 0, 0);
                        this.GetComponent<SpriteRenderer>().flipX = false;
                        break;
                    case 4:
                        transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
                        this.GetComponent<SpriteRenderer>().flipX = false;
                        break;
                    case 5:
                        transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                        this.GetComponent<SpriteRenderer>().flipX = false;
                        break;
                    case 6:
                        transform.Translate(0, -speed * Time.deltaTime, 0);
                        this.GetComponent<SpriteRenderer>().flipX = false;
                        break;
                    case 7:
                        transform.Translate(0, speed * Time.deltaTime, 0);
                        this.GetComponent<SpriteRenderer>().flipX = true;
                        break;

                }
            }
        }
    }
    private void Assault()
    {
        animator.speed = 1;
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, 3.5f * Time.deltaTime);
    }
    private void ChangeDirection()
    {
        rv = (int)(Random.value * 8);
    }
    private void Die()
    {
        int nv = (int)(Random.value * 2);
        Instantiate(collectables[nv], transform.position, transform.rotation);
        Destroy(gameObject);
    }
    #region Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            ChangeDirection();
        }
        if (collision.gameObject.tag == "Player")
        {
            Player.GetComponent<Player>().Damage();
            stop = true;
            delay = 2f;
            StartCoroutine("Stop");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            ChangeDirection();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On get attacked
        if (collision.gameObject.tag == "Rock")
        {
            if (ImPaper)
            {
                Player.GetComponent<Player>().Damage();
            }
            else if (ImScissor)
            {
                Die();
            }
        }
        if (collision.gameObject.tag == "Paper")
        {
            if (ImRock)
            {
                Die();
            }
            else if (ImScissor)
            {
                Player.GetComponent<Player>().Damage();
            }
        }
        if (collision.gameObject.tag == "Scissor")
        {
            if (ImRock)
            {
                Player.GetComponent<Player>().Damage();
            }
            else if (ImPaper)
            {
                Die();
            }
        }
    }
    #endregion
    #region Coroutines
    IEnumerator WalkingCoroutine()
    {
        yield return new WaitForSeconds(2f);
        if (timeLeft <= 0)
        {
            ChangeDirection();
            timeLeft = 4;
            StopCoroutine("WalkingCoroutine");
        }
    }
    IEnumerator Stop()
    {
        stop = true;
        yield return new WaitForSeconds(delay);
        stop = false;
        StopCoroutine("Stop");
    }
    IEnumerator Attack()
    {
        stop = true;
        animator.speed = 1f;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.4f);
        if (distance <= 1.5)
        {
            Player.GetComponent<Player>().Damage();
        }
        yield return new WaitForSeconds(0.75f);
        delay = 1f;
        StartCoroutine("Stop");
        animator.SetBool("Attack", false);
        StopCoroutine("Attack");
    }
    #endregion
}