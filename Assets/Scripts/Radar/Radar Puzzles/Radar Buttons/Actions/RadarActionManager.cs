using UnityEngine;

public class RadarActionManager : MonoBehaviour
{
    [SerializeField] private IInputHandler _inputHandler ;
    [SerializeField] private IRadarAction _radarAction;
    void Awake()
    {
        FindObjectOfType<MobileAndroid>().atack = true;
        _inputHandler = GetComponent<IInputHandler>();
        _radarAction = GetComponent<IRadarAction>();
    }
    private void Update()
    {
        OnButtonPress();
    }

    private void OnButtonPress()
    {
        if (_inputHandler.PressScissorButton())
        {
            _radarAction.ActionResult(transform.tag, "SButton", gameObject);
        }
        if (_inputHandler.PressPaperButton())
        {
            _radarAction.ActionResult(transform.tag, "PButton", gameObject);
        }
        if (_inputHandler.PressRockButton())
        {
            _radarAction.ActionResult(transform.tag, "RButton", gameObject);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<MobileAndroid>().atack = false;
    }
 }