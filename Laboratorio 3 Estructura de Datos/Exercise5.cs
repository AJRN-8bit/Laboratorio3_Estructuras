using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Estructura_de_Datos
{
    internal class Exercise5
    {
        public static void Exercise()
        {
            // Displays a description of the exercise
            Display_Info.ExersiceDescription(5, "Árbol de Dependencias de Proyecto ",
                "Muestra las dependencias de un proyecto.");

            // Creation of the tree
            DS_BinaryTree.SBinaryTree SD_BB_Tree = new DS_BinaryTree.SBinaryTree();

            // Data insertion
            SD_BB_Tree.Insert(1, " Abrir el documento     ");
            SD_BB_Tree.Insert(2, " Analizar los ejercicios");
            SD_BB_Tree.Insert(3, " Abrir VS Community     ");
            SD_BB_Tree.Insert(4, " Codificar ejercicios   ");
            SD_BB_Tree.Insert(5, " Pequeña documentación  ");
            SD_BB_Tree.Insert(6, " Entrega de ejercicios  ");
            SD_BB_Tree.Insert(7, " Descansar              ");

            // Show the data
            Console.WriteLine("ID |         Nombre         |   Dependecias");
            SD_BB_Tree.In_Order_Traverse();

            Display_Info.ShowContinue();
        }


        internal class DS_BinaryTree
        {
            public class WorkDependecy_A
            {
                public int ID;
                public string Name;
                public WorkDependecy_A left;
                public WorkDependecy_A right;

                public WorkDependecy_A(int ID, string Name)
                {
                    this.ID = ID;
                    this.Name = Name;
                    left = null;
                    right = null;
                }
            }

            public class SBinaryTree
            {
                private WorkDependecy_A root;
                public SBinaryTree()
                {
                    root = null;
                }

                public void Insert(int ID, string Name)
                {
                    root = RecursiveInsertion(root, ID, Name);
                }

                private WorkDependecy_A RecursiveInsertion(WorkDependecy_A node, int ID, string Name)
                {
                    if (node == null)
                    {
                        node = new WorkDependecy_A(ID, Name);
                        return node;
                    }

                    if (ID < node.ID)
                    {
                        node.left = RecursiveInsertion(node.left, ID, Name);
                    }
                    else if (ID > node.ID)
                    {
                        node.right = RecursiveInsertion(node.right, ID, Name);
                    }
                    return node;
                }

                public bool Search(int data)
                {
                    return RecursiveSearch(root, data);
                }

                private bool RecursiveSearch(WorkDependecy_A node, int data)
                {
                    if (node == null)
                    {
                        return false;
                    }

                    if (data == node.ID)
                    {
                        return true;
                    }
                    else if (data < node.ID)
                    {
                        return RecursiveSearch(node.left, data);
                    }
                    else if (data > node.ID)
                    {
                        return RecursiveSearch(node.right, data);
                    }
                    return false;
                }

                public void Delete(int data)
                {
                    root = RecursiveDelete(root, data);
                }

                private WorkDependecy_A RecursiveDelete(WorkDependecy_A node, int data)
                {
                    if (node == null)
                    {
                        return node;
                    }

                    if (data < node.ID)
                    {
                        node.left = RecursiveDelete(node.left, data);
                    }
                    else if (data > node.ID)
                    {
                        node.right = RecursiveDelete(node.right, data);
                    }
                    else
                    {
                        if (node.left == null)
                        {
                            return node.right;
                        }
                        else if (node.right == null)
                        {
                            // it was right before
                            return node.left;
                        }

                        // Node with two sons.
                        node.ID = GetMinimal(node.right);
                        node.right = RecursiveDelete(node.right, node.ID);
                    }
                    return node;
                }

                private int GetMinimal(WorkDependecy_A node)
                {
                    int min = node.ID;

                    while (node.left != null)
                    {
                        min = node.left.ID;
                        node = node.left;
                    }
                    return min;
                }

                public void In_Order_Traverse()
                {
                    RecursiveTraverse(root);
                }


                List<int> saveDependency = new List<int>(); // Stores the IDs of the nodes used.
                private void RecursiveTraverse(WorkDependecy_A node)
                {
                    if (node != null)
                    {
                        saveDependency.Add(node.ID - 1); // Adds the ID to the list
                        string result = string.Join(" ", saveDependency);

                        RecursiveTraverse(node.left);
                        Console.WriteLine($" {node.ID}  {node.Name}    {result}"); // Shows the results
                        RecursiveTraverse(node.right);
                    }
                }
            }
        }
    }
}
