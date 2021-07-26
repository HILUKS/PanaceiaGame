using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesPuzzle : MonoBehaviour
{
    public bool ok = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SolvePuzzle(collision);
    }

    private void SolvePuzzle(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock" && gameObject.transform.name.Equals("stoneS"))
        {
            if (!ok)
            {
                StartCoroutine("Blink");
                ok = true;
            }

        }
        if (collision.gameObject.tag == "Paper" && gameObject.transform.name.Equals("stoneR"))
        {
            if (!ok)
            {
                StartCoroutine("Blink");
                ok = true;
            }
        }
        if (collision.gameObject.tag == "Scissor" && gameObject.transform.name.Equals("stoneP"))
        {
            if (!ok)
            {
                StartCoroutine("Blink");
                ok = true;
            }
        }
    }

    IEnumerator Blink()
    {
        //audioSource.PlayOneShot(clip1, 1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<HistoryManager>().puzzleStones++;
        yield return new WaitForSeconds(1f);
        Destroy(this);
        StopCoroutine("Blink");
    }
}
