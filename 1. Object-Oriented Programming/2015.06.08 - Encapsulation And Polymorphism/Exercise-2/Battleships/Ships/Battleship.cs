using System;

namespace Battleships.Ships
{
    public abstract class Battleship : Ship, IAttack
    {
        protected void DestroyTarget(Ship target)
        {
            target.IsDestroyed = true;
        }
        public abstract string Attack(Ship target);
    }
}
