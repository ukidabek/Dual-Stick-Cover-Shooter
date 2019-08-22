public class AimInputMiddleman : BaseToggleInputMiddleman, IAim
{
    public void Activate(bool status)
    {
        Notify(status);
    }
}
