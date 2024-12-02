using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Estructura_de_Datos
{
    public class BT_Exercises
    {
        static public void Browser()
        {
            int numberSelection;
            do
            {

                // Display.
                Console.Clear();
                Display_Info.MainMenu();

                numberSelection = Extra_Functions.NumberValidation("Número de Ejercicio: ");

                Console.Clear();
                switch (numberSelection)
                { 
                    case 0: Environment.Exit(0); break;

                    case 1: Exercise1.Exercise(); break;

                    case 2: Exercise2.Exercise(); break;

                    case 3: Exercise3.Exercise(); break;

                    //case 4: Exercise4.Exercise(); break;

                    case 5: Exercise5.Exercise(); break;

                    case 6: Exercise6.Exercise(); break;

                    //case 7: Exercise7.Exercise(); break;       -- Not compleated

                    case 8: Exercise8.Exercise(); ; break;

                    case 9: Exercise9.Exercise(); break;

                    //case 10: Exercise10.Exercise(); break;     -- Not compleated

                    default: Console.WriteLine("Porfavor selecciona una de la opciones."); break;
                }
                Console.ReadKey();
            } while (numberSelection != 0);
        }
    }
}
