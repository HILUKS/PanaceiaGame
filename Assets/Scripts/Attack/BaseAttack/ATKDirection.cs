using UnityEngine;

class ATKDirection : MonoBehaviour, IATKDirection
{
    private GameObject Player;
    string Dir;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Dir = Player.GetComponent<Player>().FacingDirection;
    }
    public void AtkDirection()
    {
        if (Dir == "X-")
        {
            transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.2f);
        }
        if (Dir == "X-Y+")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
        }
        if (Dir == "X-Y-")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        }
        if (Dir == "X+")
        {
            transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y - 0.2f);
        }
        if (Dir == "X+Y+")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
        }
        if (Dir == "X+Y-")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
        }
        if (Dir == "Y-")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        }
        if (Dir == "Y+")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
        }
    }
}
