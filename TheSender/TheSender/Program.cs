using System;

using TheSender.Entities;
using TheSender.Items;
using TheSender.Events;

namespace TheSender
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo i;
            // variable bool for skipping encounters for a single cycle under certain circumstances
            bool skipEncounter;
            IEncounter encounter;
            EncounterHandler encounterHandle = new EncounterHandler();
            int t = 0;
            
            // Initialize Player
            MainPlayer player = new MainPlayer();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ████████╗██╗  ██╗███████╗    ███████╗███████╗███╗   ██╗██████╗ ███████╗██████╗ ");
            Console.WriteLine("  ╚══██╔══╝██║  ██║██╔════╝    ██╔════╝██╔════╝████╗  ██║██╔══██╗██╔════╝██╔══██╗");
            Console.WriteLine("     ██║   ███████║█████╗      ███████╗█████╗  ██╔██╗ ██║██║  ██║█████╗  ██████╔╝");
            Console.WriteLine("     ██║   ██╔══██║██╔══╝      ╚════██║██╔══╝  ██║╚██╗██║██║  ██║██╔══╝  ██╔══██╗");
            Console.WriteLine("     ██║   ██║  ██║███████╗    ███████║███████╗██║ ╚████║██████╔╝███████╗██║  ██║");
            Console.WriteLine("     ╚═╝   ╚═╝  ╚═╝╚══════╝    ╚══════╝╚══════╝╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═╝  ╚═╝");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("  A text based adventure created by Andrew Turner.");
            Console.WriteLine();

            Console.WriteLine("Press any key to start game.");
            Console.WriteLine();
            Console.ReadKey();

            
            do
            {
                encounter = null;

                Console.Clear();

                Console.WriteLine("");
                Console.WriteLine("Health: " + player.GetHealth() + "\t Location: x=" + player.xCoord + " y=" + player.yCoord);
                Console.WriteLine("Potions: " + player.GetPotions());

                Console.WriteLine("");
                Console.WriteLine("Encounter Chance: " + encounterHandle.GetEncounterChance());
                Console.WriteLine("");
                Console.WriteLine("There is nothing of interest in this room.");
                Console.WriteLine("");
                Console.WriteLine("Make your selection:");
                Console.WriteLine("===========================");
                Console.WriteLine("W - Move Up");
                Console.WriteLine("S - Move Down");
                Console.WriteLine("A - Move Left");
                Console.WriteLine("D - Move Right");
                Console.WriteLine("");
                Console.WriteLine("1 - Use Potion");

                i = Console.ReadKey(false);
                skipEncounter = false;

                switch (i.KeyChar)
                {
                    case 'w':
                    case 'W':
                        player.MoveUp();
                        break;
                    case 's':
                    case 'S':
                        player.MoveDown();
                        break;
                    case 'a':
                    case 'A':
                        player.MoveLeft();
                        break;
                    case 'd':
                    case 'D':
                        player.MoveRight();
                        break;
                    case '1':
                        player.UsePotion();
                        break;
                    case 'p':
                    case 'P':
                        t = -1;
                        break;
                    default:
                        // Invalid input, prevent encounter and encounter increment for 1 cycle
                        skipEncounter = true;
                        break;
                }




                // ==============================================
                // ENCOUNTERS
                // ==============================================
                if (!skipEncounter)
                {
                    if (encounterHandle.TestForEncounter())
                    {
                        // Determine type of encounter
                        encounter = encounterHandle.GetEncounterType();
                        Console.Clear();

                        encounter.EncounterIntro();

                        // Main encunter screen
                        encounter.EncounterMain(ref player);


                        if (encounter.IsEncounterSuccessful())
                        {
                            encounter.EncounterSuccess();
                            player.AddPotion();
                        }
                        else
                        {
                            encounter.EncounterFailure();
                        }

                        // Reset encounter variable
                        encounter = null;
                    }
                }



                // Check player health
                if (player.GetHealth() <= 0)
                {
                    // Display death sequence

                    Console.WriteLine("You have died. Thank you for playing!");

                    Console.WriteLine("");
                    Console.WriteLine("Press Enter to exit the game.");
                    Console.ReadLine();
                    t = -1;
                }
            } 
            while (t != -1); 
            

        }
    }
}
