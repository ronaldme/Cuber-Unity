namespace Assets.Scripts.Pickups
{
    public interface IItem
    {
        void TryPickup();
        bool IsPickable();
    }
}