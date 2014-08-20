namespace Assets.Scripts.Items
{
    public interface IItem
    {
        void TryPickup();
        bool IsPickable();
    }
}