using UnityEngine;

class PlayerMovement : MonoBehaviour
{
    private IInputHandler _input;
    private Player _player;
    private PlayerAnimation _playerAnimation;
    public float deadzone = 0.3f;
    private float speed = 3f;
    void Awake()
    {
        _input = GetComponent<IInputHandler>();
        _player = GetComponent<Player>();
        _playerAnimation = GetComponent<PlayerAnimation>();
}
        public void Move()
    {
        //Walk ---
        if (_input.Direction().magnitude >= deadzone)
        {
            Walk(_input.Direction());
        }
        else if (_input.Direction2().magnitude >= deadzone)
        {
            Walk(_input.Direction2());
        }
    }
    public void Walk(Vector2 Dir)
    {
        if (Dir.magnitude >= 0.1f && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying && !_player.attacking)
        {
            _playerAnimation.animator.SetBool("Walk", true);
            transform.Translate((Dir) * speed * Time.deltaTime);
            _player.StartCoroutine("Steps");
        }
        else
        {
            _playerAnimation.animator.SetBool("Walk", false);
            _player.StopCoroutine("Steps");
        }
    }
}
