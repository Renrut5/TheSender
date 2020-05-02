using System;
using System.Collections.Generic;
using System.Text;
using TheSender.Items;
using TheSender.Entities;

namespace TheSender.Events
{
    class Puzzle1 : BaseEncounter, IEncounter
    {


        public void EncounterIntro()
        {
            Console.WriteLine(@"                    //////");
            Console.WriteLine(@"             <====//////====[]");
            Console.WriteLine(@"                 /////\\\\\ ");
            Console.WriteLine(@"               ((((( ))))))))");
            Console.WriteLine(@"               ||| /\   /\ ||");
            Console.WriteLine(@"               || |_O| |O_|||");
            Console.WriteLine(@"              (9|     ^    |6)");
            Console.WriteLine(@"                 \    V   /                          )");
            Console.WriteLine(@"                 (~~~~~~~~~)                   ( ((");
            Console.WriteLine(@"                /~~~~~~~~~~~\                     )) )");
            Console.WriteLine(@"              ///////|||\\\\\\\                 (( ((");
            Console.WriteLine(@"            //                 \                )  ))");
            Console.WriteLine(@"      ______|~~~|____________|~~~|_________      (((");
            Console.WriteLine(@"    []#=====`^^^'============`^^^'========#[]    |||");
            Console.WriteLine(@" __[]_____________________________________[]___(___)_");
            Console.WriteLine(@" [____________________________________________________]");
            Console.WriteLine(@"   )   ===========================================  (");
            Console.WriteLine(@"  /  /'~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~'\  \ ");
            Console.WriteLine(@"<__/    (___________________________)               \\__>");
            Console.WriteLine("");
            Console.WriteLine(@"=====================================================================================");
            Console.WriteLine("You walk into a room and see a gypsy sitting quietly in the back corner. You");
            Console.WriteLine("slowly approach the gypsy when she offers an item in exchange for solving a puzzle. ");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();




        }
        public void EncounterMain(ref MainPlayer player) 
        {
            ConsoleKeyInfo i;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("What can you catch, but cannot throw?");
            Console.WriteLine("===========================================");
            Console.WriteLine("1 - A tennis ball");
            Console.WriteLine("2 - A cold"); // Correct Answer
            Console.WriteLine("3 - Your toys");
            Console.WriteLine("4 - A boomerang");
            Console.WriteLine("");

            Console.WriteLine("Your Response:");
            i = Console.ReadKey();

            if(i.KeyChar == '2')
            {
                isEncounterSuccessful = true;
            }

        }
        public void EncounterSuccess()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("You have answered the question correctly and the gypsy is pleased. You see");
            Console.WriteLine("her hastily write the answer into a crossword puzzle and hands you a potion");
            Console.WriteLine("for helping out.");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            // Reset encounter success tracker
            isEncounterSuccessful = false;
        }
        public void EncounterFailure()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("The gypsy ponders your answer for a moment and becomes visibly frustrated. She");
            Console.WriteLine("starts scratching out some letters on a crossword puzzle and asks you to leave.");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

    }
}
