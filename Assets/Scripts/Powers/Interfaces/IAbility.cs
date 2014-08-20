namespace Assets.Scripts.Powers.Interfaces
{
    public interface IAbility
    {
        /// <summary>
        /// Use the ability
        /// </summary>
        void UseAbility();

        /// <summary>
        /// Return true of the ability is usable.
        /// </summary>
        /// <returns></returns>
        bool IsActive();

        /// <summary>
        /// Refill the ability.
        /// </summary>
        void Fill();
    }
}