using System;
using System.Numerics;
using System.Collections;


namespace Intel8086
{
    class Program
    {
        public static string[] registerNames = { "Ax", "Bx", "Cx", "Dx" };

        public static int[] registerValues = new int[4];

        static void Main(string[] args)
        {

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Enter a value for register {0}: ", registerNames[i]);
                registerValues[i] = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("Press any key to convert all values to hexadecimal");
            Console.ReadKey();
            Console.Clear();


            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Register {0} = {1}", registerNames[i], HexConverter(registerValues[i]));
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to display main menu");
            Console.ReadKey();
            Console.WriteLine();
            Menu();

        }
        public static void Menu() { 

            Console.WriteLine();
            Console.WriteLine("Choose instruction: (enter a number)");
            Console.WriteLine("1. MOV");
            Console.WriteLine("2. SWAP");
            Console.WriteLine("3. Exit");
            int menuInput = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (menuInput)
            {
                case 1:
                    mov();
                    break;
                case 2:
                    swap();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("This option doesn't exist! Choose correct number.");
                    Menu();
                    break;
            }
        }

        public static void mov()
        { 
            
                Console.WriteLine("1. AX");
                Console.WriteLine("2. BX");
                Console.WriteLine("3. CX");
                Console.WriteLine("4. DX");
                Console.WriteLine("Choose 1st register (enter a number)");
                int register1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Choose 2nd register (enter a number)");
                int register2 = int.Parse(Console.ReadLine());

                registerValues[register2 - 1] = registerValues[register1 - 1];

                Console.WriteLine();
                Console.WriteLine("New registers values: ");
                for (int i = 0; i < 4; i++)
                {
                    
                    Console.WriteLine("Register {0} = {1}", registerNames[i], HexConverter(registerValues[i]));
                }

                Console.WriteLine("Press any key to go to main menu");
                Console.ReadKey();
                Console.Clear();
                Menu();

        }

        public static void swap()
        {
            Console.WriteLine("1. AX");
            Console.WriteLine("2. BX");
            Console.WriteLine("3. CX");
            Console.WriteLine("4. DX");
            Console.WriteLine("Choose register which you want to swap (enter a number)");
            int register = int.Parse(Console.ReadLine());
             
            
            Console.WriteLine("Enter a new value for that register");
            registerValues[register - 1] = int.Parse(Console.ReadLine());


            Console.WriteLine();
            Console.WriteLine("New registers values: ");
            for (int i = 0; i < 4; i++)
            {

                Console.WriteLine("Register {0} = {1}", registerNames[i], HexConverter(registerValues[i]));
            }

            Console.WriteLine("Press any key to go to main menu");
            Console.ReadKey();
            Console.Clear();
            Menu();

        }


        //decimal to hexadecimal converter
        public static string HexConverter(int value)
        {
            if (value < 1) return "0";

            int hex = value;
            string hexString = string.Empty;

            while (value > 0)
            {
                hex = value % 16;

                if (hex < 10)
                    hexString = hexString.Insert(0, Convert.ToChar(hex + 48).ToString());
                else
                    hexString = hexString.Insert(0, Convert.ToChar(hex + 55).ToString());

                value /= 16;
            }

            return hexString;
        }

    }
}
