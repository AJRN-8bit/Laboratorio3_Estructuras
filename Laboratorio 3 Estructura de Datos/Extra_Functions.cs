using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Estructura_de_Datos
{
    public class Extra_Functions
    {
        // It helps know if the input of the user is correct.
        public static int NumberValidation(string text)
        {
            sbyte number;
            Console.Write(text);
            string userInput = Console.ReadLine();
            bool isvalid = sbyte.TryParse(userInput, out number);
            if (isvalid == true)
                return number;

            return -1;
        }




        // It return a boolean value if depending of the desition of the user.
        public static bool Repeat(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message + "  [1] Si, [ENTER] No");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                return true;
            }
            else { return false; }
        }


        //public static 

       
    }

}
