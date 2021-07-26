using UnityEngine;

public class RadarButtonPuzzle : MonoBehaviour, IRadarPuzzle
{
    [SerializeField] private GameObject[] buttonType = new GameObject[3];
    private Radar _radar;
    private int rv;
    private void Awake()
    {
        _radar = FindObjectOfType<Radar>();
    }
    public void InstantiatePuzzle()
    {
        rv = (int)(Random.value * 3);
        if (_radar.theButton == null)
        {
            _radar.theButton = Instantiate(buttonType[rv], transform.position, transform.rotation, transform.parent = transform);
        }
        else
        {
            Destroy(_radar.theButton);
            _radar.theButton = Instantiate(buttonType[rv], transform.position, transform.rotation, transform.parent = transform);
        }
    }
}

