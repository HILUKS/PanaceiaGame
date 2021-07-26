public class Heart : Colletable
{
    public override void Collect()
    {
        Destroy(Instantiate(SFX, transform.position, transform.rotation), 1f);
        if (FindObjectOfType<Player>().life < 5)
        {
            FindObjectOfType<Player>().life++;
            Destroy(gameObject);
        }
    }
}