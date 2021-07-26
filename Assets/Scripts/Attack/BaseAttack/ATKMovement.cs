using UnityEngine;

class ATKMovement : MonoBehaviour, IATKMovement
{
    private GameObject Player;
    string Dir;
    public float speed;
    public float diagonalSpeed;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Dir = Player.GetComponent<Player>().FacingDirection;
        speed = 5f;
        diagonalSpeed = 5f;
    }
    public void AtkMovement()
    {
        if (Dir == "X-")
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Dir == "X-Y+")
        {
            transform.Translate(-diagonalSpeed * Time.deltaTime, diagonalSpeed * Time.deltaTime, 0);
        }
        if (Dir == "X-Y-")
        {
            transform.Translate(-diagonalSpeed * Time.deltaTime, -diagonalSpeed * Time.deltaTime, 0);
        }
        if (Dir == "X+")
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Dir == "X+Y+")
        {
            transform.Translate(diagonalSpeed * Time.deltaTime, diagonalSpeed * Time.deltaTime, 0);
        }
        if (Dir == "X+Y-")
        {
            transform.Translate(diagonalSpeed * Time.deltaTime, -diagonalSpeed * Time.deltaTime, 0);
        }
        if (Dir == "Y-")
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (Dir == "Y+")
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        Destroy(gameObject, 1.0f);
    }
}