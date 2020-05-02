using System;
using System.Collections.Generic;
using System.Text;

namespace TheSender.Entities
{
    interface IEntity
    {
        public void TakeDamage(int damage); // When this entity takes damage
        public int GetAttackDamage();
        public int GetHealth();
    }
}
