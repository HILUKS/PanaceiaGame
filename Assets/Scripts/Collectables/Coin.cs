public class Coin : Colletable
{
    public override void Collect()
    {
        FindObjectOfType<HistoryManager>().coin++;
        Destroy(Instantiate(SFX, transform.position, transform.rotation), 1f);
        Destroy(gameObject);
    }
}
