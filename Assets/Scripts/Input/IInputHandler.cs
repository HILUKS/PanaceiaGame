using UnityEngine;

public interface IInputHandler
{
    Vector2 Direction();
    Vector2 Direction2();
    bool PressInteractButton();
    bool PressPaperButton();
    bool PressRadarButton();
    bool PressRockButton();
    bool PressScissorButton();
}