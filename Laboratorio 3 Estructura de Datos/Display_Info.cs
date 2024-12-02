using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Estructura_de_Datos
{
    public class Display_Info
    {
        public static void MainMenu()
        {
            Console.WriteLine("--- Árboles binarios ---");
            Console.WriteLine();
            Console.WriteLine("- Selecciona un ejercicio para ejecutarlo: -");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("[1] Árbol de Decisiones para Clasificación de Objetos.");
            Console.WriteLine();
            Console.WriteLine("[2] Evaluación de Expresiones Booleanas.");
            Console.WriteLine();
            Console.WriteLine("[3] Árbol Binario de Búsqueda para Inventario de Productos.");
            Console.WriteLine();
            Console.WriteLine("[4] Árbol AVL para Optimización de Prioridades en Servicios.    -- No completado");
            Console.WriteLine();
            Console.WriteLine("[5] Árbol de Dependencias de Proyecto.");
            Console.WriteLine();
            Console.WriteLine("[6] Cálculo de Operaciones Matemáticas con Árboles Binarios.");
            Console.WriteLine();
            Console.WriteLine("[7] Sistema Jerárquico de Archivos con Árboles.  -- No completado");
            Console.WriteLine();
            Console.WriteLine("[8] Árbol de Categorías de Productos.");
            Console.WriteLine();
            Console.WriteLine("[9] Registro de Contactos en un Árbol Binario de Búsqueda.");
            Console.WriteLine();
            Console.WriteLine("[10] Sistema de Manejo de Inventario con Árbol AVL por Cantidad en Stock.  -- No completado");
            Console.WriteLine();
            Console.WriteLine("[0] Cerrar programa");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine();
        }

        public static void ExersiceDescription(int number, string title, string description)
        {
            Console.Clear();
            Console.WriteLine($"Ejercicio {number}:");
            Console.WriteLine();
            Console.WriteLine("---=-=- " + title + " -=-=---");
            Console.WriteLine("Funcionamiento: " + description);
            Console.WriteLine();
        }

        public static void ExerciseOptions(string option1, string option2, string option3, string option4, string option5)
        {
            Console.WriteLine("[1] " + option1);
            Console.WriteLine("[2] " + option2);
            Console.WriteLine("[3] " + option3);
            Console.WriteLine("[4] " + option4);
            Console.WriteLine("[5] " + option5);
            Console.WriteLine("[0] Salir a menu Colas.");
            Console.WriteLine();
        }

        public static void ShowContinue()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Oprima [ENTER] para continuar.");
        }
    }
}
