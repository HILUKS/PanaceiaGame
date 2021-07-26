using UnityEngine;

    public class RadarMovement : MonoBehaviour, IRadarMovement
    {
        [SerializeField] private int distance;
        private GameObject Player;
        private string Dir;
        private void Awake()
        {
            distance = 1;
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        public void RadarPosition()
        {
            Dir = Player.GetComponent<Player>().FacingDirection;
            if (Dir == "X-")
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - distance, Player.transform.position.y, Player.transform.position.z), 5 * Time.deltaTime);
            }
            if (Dir == "X-Y+")
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - distance, Player.transform.position.y + distance, Player.transform.position.z), 5 * Time.deltaTime);
            }
            if (Dir == "X-Y-")
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - distance, Player.transform.position.y - distance, Player.transform.position.z), 5 * Time.deltaTime);
            }
            if (Dir == "X+")
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x + distance, Player.transform.position.y, Player.transform.position.z), 5 * Time.deltaTime);
            }
            if (Dir == "X+Y+")
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x + distance, Player.transform.position.y + distance, Player.transform.position.z), 5 * Time.deltaTime);
            }
            if (Dir == "X+Y-")
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x + distance, Player.transform.position.y - distance, Player.transform.position.z), 5 * Time.deltaTime);
            }
            if (Dir == "Y-")
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y - distance, Player.transform.position.z), 5 * Time.deltaTime);
            }
            if (Dir == "Y+")
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + distance, Player.transform.position.z), 5 * Time.deltaTime);
            }
        }
}