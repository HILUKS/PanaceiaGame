using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject Paper;
    [SerializeField] private GameObject Scissor;
    [SerializeField] private GameObject radar;
    [SerializeField] private GameObject objRadar;
    [HideInInspector] public string FacingDirection = "Y-";
    [HideInInspector] public int life;
    private IInputHandler _input;
    private PlayerMovement _movement;
    private PlayerAnimation _playerAnimation;
    private PlayerHealth _playerHealth;
    private int cv;
    private bool endHurt = true;
    //Sound
    public AudioSource audioSource;
    public AudioSource stepSource;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip[] steps = new AudioClip[5];
    public bool playAgain;
    //ATK
    private GameObject attackGO;
    public bool attacking;
    //Android
    public SimpleTouchController leftController;
    private void Awake()
    {
        life = 5;
        _input = GetComponent<IInputHandler>();
        _movement = GetComponent<PlayerMovement>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        _movement.Move();
        _playerAnimation.Animation();
        _playerHealth.LifeUI();
        Attack();
        //tirar
        //Radar
        if (Input.GetKeyDown(KeyCode.Space) && objRadar == null && !attacking && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying || Input.GetKeyDown(KeyCode.JoystickButton5) && objRadar == null && !attacking && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying)
        {
            if (FindObjectOfType<HistoryManager>().radarEnabled)
            {
                objRadar = Instantiate(radar, transform.position, transform.rotation, transform.parent = transform);
                FindObjectOfType<MobileAndroid>().radar = true;
            }
        }
    }
    private void Attack()
    {
        if (FindObjectOfType<HistoryManager>().atackEnabled && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying && !attacking)
        {
            if (_input.PressRockButton())
            {
                attackGO = Rock;
                StartCoroutine("PlayerAttack");
            }
            else
            if (_input.PressPaperButton())
            {
                attackGO = Paper;
                StartCoroutine("PlayerAttack");
            }
            else
            if (_input.PressScissorButton())
            {
                attackGO = Scissor;
                StartCoroutine("PlayerAttack");
            }
        }
    }
    
    //Attack
    IEnumerator PlayerAttack()
    {
        attacking = true;
        _playerAnimation.animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.33f);
        audioSource.PlayOneShot(clip2, 1f);
        Instantiate(attackGO, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        _playerAnimation.animator.SetBool("Attack", false);
        attacking = false;
    }
    //Radar
    public void DestroyRadar()
    {
        if(objRadar != null)
        {
            FindObjectOfType<HistoryManager>().atackEnabled = true;
            Destroy(objRadar);
        }
    }
    //Health
    public void Damage()
    {
        if(endHurt)
        {
            life--;
            endHurt = false;
            StartCoroutine("Blink");
        }
    }
    IEnumerator Blink()
    {
        audioSource.PlayOneShot(clip1, 1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(1f);
        endHurt = true;
        StopCoroutine("Blink");
    }
    //Audio
    IEnumerator Steps()
    {
        cv = (int)(Random.value * 4);
        if (playAgain) 
        {
            stepSource.PlayOneShot(steps[cv], 0.1f);
            playAgain = false;
        }
        yield return new WaitForSeconds(0.3f);
        playAgain = true;
        StopCoroutine("Steps");
    }
    #region AndroidOld
    /*
     public void RockB()
     {
         if (FindObjectOfType<HistoryManager>().atackEnabled && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying && !attacking)
         {
             StartCoroutine("RockAttack");
         }
     }
     public void RockP()
     {
         if (FindObjectOfType<HistoryManager>().atackEnabled && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying && !attacking)
         {
             StartCoroutine("PaperAttack");
         }
     }
     public void RockS()
     {
         if (FindObjectOfType<HistoryManager>().atackEnabled && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying && !attacking)
         {
             StartCoroutine("ScissorAttack");
         }
     }
     public void Radar()
     {
         if ( objRadar == null && !attacking && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying)
         {
             if (FindObjectOfType<HistoryManager>().radarEnabled)
             {
                 objRadar = Instantiate(radar, transform.position, transform.rotation, transform.parent = transform);
                 //FindObjectOfType<MobileAndroid>().radP = objRadar;
             }
         }
     }
    */
    #endregion
}