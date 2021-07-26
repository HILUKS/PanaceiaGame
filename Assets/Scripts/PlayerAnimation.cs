using UnityEngine;

class PlayerAnimation : MonoBehaviour
{
    public IInputHandler _input;
    private PlayerMovement _movement;
    private Player _player;
    private Vector2 direction;
    private Vector2 direction2;
    private float vertical;
    private float vertical2;
    private float horizontal;
    private float horizontal2;
    public Animator animator;
    void Awake() 
    {
        animator = GetComponent<Animator>();
        _input = GetComponent<IInputHandler>();
        _movement = GetComponent<PlayerMovement>();
        _player = GetComponent<Player>();
    }
    public void Animation()
    {
        direction = _input.Direction();
        direction2 = _input.Direction2();
        horizontal = direction.x;
        horizontal2 = direction2.x;
        vertical = direction.y;
        vertical2 = direction2.y;
        if (direction.magnitude == 0 && direction2.magnitude == 0)
        {
            animator.SetBool("Walk", false);
        }
        //Facing Direction 
        FacingDirection();
    }
    private void FacingDirection()
    {
        if (!FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying && !_player.attacking)
        {
            if (horizontal > _movement.deadzone || horizontal2 > _movement.deadzone)
            {
                if (vertical > -_movement.deadzone && vertical < _movement.deadzone && vertical2 > -_movement.deadzone && vertical2 < _movement.deadzone)
                {
                    _player.FacingDirection = "X+";
                    animator.SetBool("Right", true);
                    animator.SetBool("Up", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Down", false);
                }
                if (vertical > _movement.deadzone || vertical2 > _movement.deadzone)
                {
                    _player.FacingDirection = "X+Y+";
                    animator.SetBool("Up", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Down", false);
                }
                if (vertical < -_movement.deadzone || vertical2 < -_movement.deadzone)
                {
                    _player.FacingDirection = "X+Y-";
                    animator.SetBool("Down", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Up", false);
                }
            }
            if (horizontal < -_movement.deadzone || horizontal2 < -_movement.deadzone)
            {
                if (vertical > -_movement.deadzone && vertical < _movement.deadzone && vertical2 > -_movement.deadzone && vertical2 < _movement.deadzone)
                {
                    _player.FacingDirection = "X-";
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                }
                if (vertical > _movement.deadzone || vertical2 > _movement.deadzone)
                {
                    _player.FacingDirection = "X-Y+";
                    animator.SetBool("Up", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Down", false);
                }
                if (vertical < -_movement.deadzone || vertical2 < -_movement.deadzone)
                {
                    _player.FacingDirection = "X-Y-";
                    animator.SetBool("Down", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Up", false);
                }
            }
            if (vertical > _movement.deadzone || vertical2 > _movement.deadzone)
            {
                if (horizontal > -_movement.deadzone && horizontal < _movement.deadzone && horizontal2 > -_movement.deadzone && horizontal2 < _movement.deadzone)
                {
                    _player.FacingDirection = "Y+";
                    animator.SetBool("Up", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Down", false);
                }
            }
            if (vertical < -_movement.deadzone || vertical2 < -_movement.deadzone)
            {
                if (horizontal > -_movement.deadzone && horizontal < _movement.deadzone && horizontal2 > -_movement.deadzone && horizontal2 < _movement.deadzone)
                {
                    _player.FacingDirection = "Y-";
                    animator.SetBool("Down", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Up", false);
                }
            }
        }
    }
}