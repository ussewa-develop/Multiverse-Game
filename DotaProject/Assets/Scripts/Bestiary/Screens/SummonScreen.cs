
public class SummonScreen : EntityScreen
{
    private void Start()
    {
        EventController.SwitchMenu += Destroy;
    }

    private void Destroy()
    {
        Destroy(gameObject);
        EventController.SetStandartY();
    }

    private void OnDestroy()
    {
        EventController.SwitchMenu -= Destroy;
    }
}
