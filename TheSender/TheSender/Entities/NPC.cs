using System;
using System.Collections.Generic;
using System.Text;

namespace TheSender.Entities
{
    class NPC : BaseEntity
    {
        public NPC()
        {
            health = 50;
            armor = 0;
            attackDamage = 10;
        }
    }
}
