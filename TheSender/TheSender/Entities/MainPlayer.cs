using System;
using System.Collections.Generic;
using System.Text;
using TheSender.Items;
namespace TheSender.Entities
{
    class MainPlayer : BaseEntity
    {
        private const int BASE_ATTACK_DAMAGE = 10;
        private const int STARTING_POTION_COUNT = 5;
        private const int MAX_HEALTH = 100;
        private const int STARTING_HEALTH = MAX_HEALTH;


        // Player position
        public int xCoord;
        public int yCoord;

        // Quantity of potions
        private int potions;

        // Potion object that returns amount healed
        private Potion potionHandler { get; set; }

        public MainPlayer()
        {
            health = STARTING_HEALTH;

            if(health > MAX_HEALTH)
            {
                health = MAX_HEALTH;
            }

            armor = 0;
            attackDamage = BASE_ATTACK_DAMAGE;

            xCoord = 0;
            yCoord = 0;
            potions = STARTING_POTION_COUNT;

            potionHandler = new Potion();
        }

        #region Movement Methods
        public void MoveUp()
        {
            this.yCoord += 1;
        }

        public void MoveDown()
        {
            this.yCoord -= 1;
        }

        public void MoveLeft()
        {
            this.xCoord -= 1;
        }
        public void MoveRight()
        {
            this.xCoord += 1;
        }
        #endregion



        public int GetPotions()
        {
            return potions;
        }

        public void AddPotion()
        {
            potions += 1;
        }

        public void UsePotion()
        {
            // Only use potion if player has at least 1 potion and 
            // not at max health
            if(potions > 0 && health < MAX_HEALTH)
            {
                health += potionHandler.HealingValue;
                // Don't let health go above max value
                if(health > MAX_HEALTH)
                {
                    health = MAX_HEALTH;
                }
                // Decrement potions by 1
                potions -= 1;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Not enough potions or already at max health.");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
            
        }


    }
}
