using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    class Program
    {

        static void runProgram() {
            StateMachine cookSmart = new StateMachine();
            cookSmart.startUp();


        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            runProgram();
            Console.Write("Thanks for thinking"+"\n");
            Console.ReadLine();
        }
    }
}
