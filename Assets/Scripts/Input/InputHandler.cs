using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputHandler : MonoBehaviour, IInputHandler
{
    public bool PressScissorButton()
    {
        return Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.JoystickButton3);
    }
    public bool PressPaperButton()
    {
        return Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.JoystickButton2);
    }
    public bool PressRockButton()
    {
        return Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.JoystickButton1);
    }
    public bool PressRadarButton()
    {
        return Input.GetKeyDown(KeyCode.Space) && !FindObjectOfType<Player>().attacking && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying || Input.GetKeyDown(KeyCode.JoystickButton5) && !FindObjectOfType<Player>().attacking && !FindObjectOfType<DialogueManager>().onDialogue && !FindObjectOfType<HistoryManager>().animationIsPlaying;
    }
    public bool PressInteractButton()
    {
        return Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton0);
    }
    public Vector2 Direction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector3(horizontal, vertical);
        return direction;

    }
    public Vector2 Direction2()
    {
        float horizontal2 = Input.GetAxisRaw("DpadH");
        float vertical2 = Input.GetAxisRaw("DpadV");
        //float horizontal2   = CnInputManager.GetAxis("Horizontal");
        //float vertical2 = CnInputManager.GetAxis("Vertical");
        Vector2 direction2 = new Vector3(horizontal2, vertical2);
        return direction2;
    }
}
