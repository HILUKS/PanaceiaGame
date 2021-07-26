using UnityEngine;
using UnityEngine.SceneManagement;
class PlayerHealth : MonoBehaviour
{
    private Player _player;
    public GameObject[] lifeButton = new GameObject[5];
    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    public void LifeUI()
    {
        if (_player.life == 5)
        {
            lifeButton[4].SetActive(true);
        }
        if (_player.life == 4)
        {
            lifeButton[4].SetActive(false);
            lifeButton[3].SetActive(true);
        }
        if (_player.life == 3)
        {
            lifeButton[3].SetActive(false);
            lifeButton[2].SetActive(true);
        }
        if (_player.life == 2)
        {
            lifeButton[2].SetActive(false);
            lifeButton[1].SetActive(true);
        }
        if (_player.life == 1)
        {
            lifeButton[1].SetActive(false);
            lifeButton[0].SetActive(true);
        }
        if (_player.life <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}