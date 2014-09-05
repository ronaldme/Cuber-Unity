namespace Assets.Scripts.Pickups
{
    public interface IPickable
    {
        void TryPickup();
        bool IsPickable();
    }
}