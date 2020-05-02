using System;
using System.Collections.Generic;
using System.Text;

namespace TheSender.Events
{
    class EncounterHandler
    {
        private const int BASE_ENCOUNTER_CHANCE = 5;
        private const int ENCOUNTER_CHANCE_INCREMENT = 1;
        
        private int encounterChance;
        private Random NumberGenerator;


        public EncounterHandler()
        {
            encounterChance = BASE_ENCOUNTER_CHANCE;
            NumberGenerator = new Random();
        }

        /**
         * Random number generator that tests for random encounter.
         * Number is generated and compared against Random Encounter chance.
         * If false, increments the encounter chance to make it increasingly likely that an encounter will happen.
         */
        public bool TestForEncounter()
        {
            int randomNumber = NumberGenerator.Next(0, 100);

            if (randomNumber <= encounterChance)
            {
                encounterChance = BASE_ENCOUNTER_CHANCE;
                return true;
            }
            else
            {
                encounterChance += ENCOUNTER_CHANCE_INCREMENT;
                return false;
            }
        }

        
        // Returns an encounter type, allows for different types of encounters based on random number generator
        // Currently only 2 encounters and enounter types (1 each) and based on 65% chance to be non-aggressive encounter
        public IEncounter GetEncounterType()
        {
            int randomNumber = NumberGenerator.Next(0, 100);

            if(randomNumber > 70)
            {
                return new Puzzle1();
            }
            else
            {
                return new EnemyEncounter();
            }
        }

        public int GetEncounterChance()
        {
            return encounterChance;
        }



    }
}
