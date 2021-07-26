using System.Collections;
using UnityEngine;

public partial class RedHand
{
    public class RedHandFallAttack : MonoBehaviour, IRedHandAttack
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Collider2D col;
        [SerializeField] private RedHand _redHand;
        public void Attack()
        {
            if (_redHand.distance < 0.1f)
            {
                StartCoroutine("Fall");
            }
        }
        IEnumerator Fall()
        {
            _redHand.stop = true;
            yield return new WaitForSeconds(0.2f);
            animator.SetBool("Down", true);
            yield return new WaitForSeconds(0.3f);
            col.enabled = true;
            if (!this.GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().Play();
            }
            yield return new WaitForSeconds(2.5f);
            animator.SetBool("Down", false);
            animator.SetBool("Up", true);
            yield return new WaitForSeconds(0.3f);
            col.enabled = false;
            yield return new WaitForSeconds(0.2f);
            animator.SetBool("Up", false);

            _redHand.stop = false;
            StopCoroutine("Fall");
        }
    }
}
