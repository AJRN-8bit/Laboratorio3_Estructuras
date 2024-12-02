using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Estructura_de_Datos
{
    internal class Exercise1
    {
        public static void Exercise()
        {
            // Displays a description of the exercise
            Display_Info.ExersiceDescription(1, "Árbol de Decisiones para Clasificación de Objetos",
                "Aplicar árboles binarios para clasificar objetos mediante un árbol de decisiones.");

            // Creation of the tree
            Binary_Tree_Struc.DesitionTree B_Tree = new Binary_Tree_Struc.DesitionTree();

            // Insertion of the messages
            B_Tree.root = new Binary_Tree_Struc.DesitionNode("¿Es rojo?");
            B_Tree.root.left = new Binary_Tree_Struc.DesitionNode("Si es rojo, ¿es redonda?");
            B_Tree.root.left.left = new Binary_Tree_Struc.DesitionNode("Si es redonda, es una manzana.");
            B_Tree.root.left.right = new Binary_Tree_Struc.DesitionNode("Si no es redonda, es una fresa.");
            B_Tree.root.right = new Binary_Tree_Struc.DesitionNode("Si no es rojo, ¿es largo?");
            B_Tree.root.right.left = new Binary_Tree_Struc.DesitionNode("Si es largo, es un plátano.");
            B_Tree.root.right.right = new Binary_Tree_Struc.DesitionNode("Si no es largo, es una uva.");

            // Tree methods
            B_Tree.DesitionMaking();
            Console.WriteLine();
            Console.WriteLine("Recorrido:");
            B_Tree.PreOrderTraverse(B_Tree.root);

            Display_Info.ShowContinue();

        }


        internal class Binary_Tree_Struc
        {
            public class DesitionNode
            {
                public string message;
                public DesitionNode left;
                public DesitionNode right;
                public DesitionNode(string message)
                {
                    this.message = message;
                    left = null;
                    right = null;
                }
            }

            public class DesitionTree
            {
                public DesitionNode root;
                public DesitionTree()
                {
                    root = null;
                }

                // This tree structure is small because it dosent use lot of the other methods.

                public void DesitionMaking()
                {
                    DesitionNode current = root;
                    while(current != null)
                    {
                        Console.WriteLine(current.message);
                        Console.Write("Respuesta Y[Si], N[No]:  ");
                        string answer = Console.ReadLine().ToUpper();

                        if (answer == "Y")
                        {
                            // Moves to the left side
                            current = current.left;
                        }
                        else if (answer == "N")
                        {
                            // Moves to the right side
                            current = current.right;
                        }
                        else
                        {
                            // Cheks for invalid inputs.
                            Console.WriteLine("Opción invalida.");
                            Console.WriteLine();
                        }
                    }
                }

                public void PreOrderTraverse(DesitionNode node)
                {
                    if (node == null) return;
                    Console.WriteLine(node.message + " "); // Goes to the root
                    PreOrderTraverse(node.left); // Traverse the left side
                    PreOrderTraverse(node.right);  // Traverse the right side
                }
            }
        }
    }
}
