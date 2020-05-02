using System;
using System.Collections.Generic;
using System.Text;

namespace TheSender.Entities
{
    abstract class BaseEntity : IEntity
    {
        protected int health;
        protected int armor;
        protected int attackDamage;

        
        virtual public int GetAttackDamage()
        {
            return attackDamage;
        }
        
        public void TakeDamage(int damage)
        {
            int totalDamage;

            if(armor > 0)
            {
                totalDamage = (armor / 100) * damage;
            }
            else
            {
                totalDamage = damage;
            }

            health -= totalDamage;
        }

        public int GetHealth()
        {
            return health;
        }

    }
}
