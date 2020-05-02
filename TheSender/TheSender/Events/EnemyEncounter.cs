using System;
using TheSender.Entities;

namespace TheSender.Events
{
    class EnemyEncounter : BaseEncounter, IEncounter
    {
        public NPC enemy;

        public EnemyEncounter()
        {
            enemy = new NPC();
        }

        public void EncounterIntro()
        {
            Console.Clear();

            Console.WriteLine("                    dS$$S$S$S$S$S$S$$Sb ");
            Console.WriteLine("                   :$$S^S$S$S$S$S$S^S$$;");
            Console.WriteLine("                   SSP   `^$S$S$^'   TSS");
            Console.WriteLine("                   $$       `\"'       $$");
            Console.WriteLine("                  _SS ,-           -  SS_");
            Console.WriteLine("                 :-.|  _    - .-   _  |.-;");
            Console.WriteLine("                 :\\(; ' \" -._.'._.-\" ` |)/;");
            Console.WriteLine("                  \\`|  , o       o .  |'/ ");
            Console.WriteLine("                   \":     -'   `-     ;\"");
            Console.WriteLine("                     ;.              :  ");
            Console.WriteLine("                     : `    ._.    ' ;");
            Console.WriteLine("                   .sSb   ._____.   dSs.");
            Console.WriteLine("                _.d8dSSb.   ._.   .SSbT8b._");
            Console.WriteLine("            _.oOPd88SSSS T.     .P SSSS888OOo.");
            Console.WriteLine("        _.mMMOOPd888SSSSb TSqqqSP dSSSS88OMOOOMm._");
            Console.WriteLine("     .oOMMMOMOOM8O8OSSSSSb TSSSP dSSSSS8OOMMOOMMOOOo._");
            Console.WriteLine("   .OOMMOOOMMOOMOOOO  \" ^ SSSTSSP dSSS ^ \"OOOOMOOMOOMMMb.");
            Console.WriteLine("  dOOOMMMOMMOOOMOOOO      \" ^ SSSS ^ \"   :OOO8MMOMOOMMOMMb");
            Console.WriteLine(" :MMMOOMMOMMOOMMO8OS         `P      8O8OPdMMOOMMOMMOMMMM;");
            Console.WriteLine(" MMMMOOMMMMMOOMbTO8S;               :8888MMMMMOMMOMMOMMMMM");
            Console.WriteLine(" OMMMMOOMMMMOOOMMOOOS        S     :O8OPdMOMMMOMOMMOOMMMMO");
            Console.WriteLine(":OMMMMOOMMOMMOOMbTObTb.     :S;   .PdOPdMOOMMMMMOMMOMMMMMO;");
            Console.WriteLine("MOOMMMMOMMOMMOOMMMOObTSSg._.SSS._.PdOPdMOOMMMMOMMMMOMMMMOOM");
            Console.WriteLine("MMOMMMMOMMMOMMOOMMbT8bTSSSSSSSSSPd8OPdOOOMMMMOOMMMMOMMMOOMM");
            Console.WriteLine("MMOMMMOMMMMMOMMOOMMMbT8bTSSSSSPd88PdOOOOMMMMOOMMMMMMMMOOMMM");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("A suspicious man named Layton Blevins appears from around the corner. ");
            Console.WriteLine("Without warning, he attacks you.");
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

        }


        public void EncounterMain(ref MainPlayer player)
        {
            string message = "";
            ConsoleKeyInfo i;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Player");
                Console.WriteLine("===================");
                Console.WriteLine("Health: " + player.GetHealth());
                Console.WriteLine("Potions: " + player.GetPotions());
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Layton Blevins");
                Console.WriteLine("===================");
                Console.WriteLine("Health: " + enemy.GetHealth());
                Console.WriteLine("");
                Console.WriteLine("");

                if (message != "")
                {
                    Console.WriteLine("");
                    Console.WriteLine(message);
                    Console.WriteLine("");
                }

                Console.WriteLine("");
                Console.WriteLine("Make your selection:");
                Console.WriteLine("==========================");
                Console.WriteLine("1 - Attack");
                Console.WriteLine("2 - Use Potion");
                Console.WriteLine("");
                
                i = Console.ReadKey(false);
                switch (i.KeyChar)
                {
                    case '1':
                        enemy.TakeDamage(player.GetAttackDamage());
                        break;
                    case '2':
                        player.UsePotion();
                        break;
                }

                // EnemyEncounter Action
                if (enemy.GetHealth() > 0)
                {
                    player.TakeDamage(enemy.GetAttackDamage());
                    message = "Layton attacks you for 10 damage.";
                }
            }
            while (player.GetHealth() > 0 && enemy.GetHealth() > 0 );

            if(enemy.GetHealth() <= 0 && player.GetHealth() > 0)
            {
                isEncounterSuccessful = true;
            }
        }

        public void EncounterSuccess()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("In a desparate struggle for your life, you manage to push Blevins off of");
            Console.WriteLine("you and begin to run away. After chasing you for a short distance, Blevins");
            Console.WriteLine("suddenly stops and turns around. ");
            Console.WriteLine("");
            Console.WriteLine("Best be careful, he may come back looking to finish what he started.");

            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            // Reset encounter success tracker
            isEncounterSuccessful = false;
        }
        public void EncounterFailure()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("During your brawl with Blevins, he manages to get the best of you and");
            Console.WriteLine("pins you to the ground and begins to choke you. As you struggle to find");
            Console.WriteLine("even just one last breath, everything goes dark.");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

    }
}
