using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Laboratorio_3_Estructura_de_Datos
{
    internal class Exercise4
    {
        public static void Exercise()
        {
            // Displays a description of the exercise
            Display_Info.ExersiceDescription(4, "Árbol AVL para Optimización de Prioridades en Servicios",
                "Usar árboles AVL para organizar tareas o servicios en función de su prioridad.");

            // Creation of the tree
            AVL_BinaryTree.Priority_AVL_Tree avl_tree = new AVL_BinaryTree.Priority_AVL_Tree();

            // Data insertion
            // The higher the number, the higher the priority
            avl_tree.Insert(1, "Convivio", 7);
            avl_tree.Insert(2, "Tarea de algoritmos", 6);
            avl_tree.Insert(3, "Tarea de base de datos", 4);
            avl_tree.Insert(4, "Tarea de sistemas", 5);
            avl_tree.Insert(5, "Tarea de emprendimiento", 2);
            avl_tree.Insert(6, "Tarea de cálculo", 3);
            avl_tree.Insert(7, "Tarea de Canon", 1);


            // work on standby
            avl_tree.In_Order_Traverse(false);
            avl_tree.In_Order_Traverse(true);
            Console.WriteLine(avl_tree.ShowHeight());

            Display_Info.ShowContinue();

        }


        public class AVL_BinaryTree
        {
            public class Task
            {
                public int height;
                public int ID;
                public string description;
                public int priority;
                public Task left;
                public Task right;
                public Task(int ID, string description, int priority)
                {
                    this.ID = ID;
                    this.description = description;
                    this.priority = priority;
                    left = null;
                    right = null;
                }
            }

            public class Priority_AVL_Tree
            {
                private Task root;
                public Priority_AVL_Tree()
                {
                    root = null;
                }

                private int GetHeight(Task node)
                {
                    return node == null ? 0 : node.height; // Same as if()
                }

                private int GetBalance(Task node)
                {
                    return node == null ? 0 : GetHeight(node.left) - GetHeight(node.right);
                }
                public int ShowHeight() => GetHeight(root);

                // Rotations:
                private Task RightRotation(Task yNode)
                {
                    Task xNode = yNode.left;
                    Task t2Node = xNode.right;

                    // Rotation
                    xNode.right = yNode;
                    yNode.left = t2Node;

                    // Update the heights
                    yNode.height = Math.Max(GetHeight(yNode.left), GetBalance(yNode.right)) + 1;
                    xNode.height = Math.Max(GetHeight(xNode.left), GetBalance(xNode.right)) + 1;

                    return xNode;

                }

                private Task LeftRotation(Task xNode)
                {
                    Task yNode = xNode.right;
                    Task t2Node = yNode.left;

                    // Rotation
                    yNode.left = xNode;
                    xNode.right = t2Node;

                    // Update the heights
                    xNode.height = Math.Max(GetHeight(xNode.left), GetBalance(xNode.right)) + 1;
                    yNode.height = Math.Max(GetHeight(yNode.left), GetBalance(yNode.right)) + 1;

                    return yNode;

                }

                // Data insertion
                public void Insert(int ID, string description, int priority)
                {
                    root = InsertNode(root, ID, description, priority);
                }
                private Task InsertNode(Task node, int ID, string description, int priority)
                {
                    if (node == null)
                        return new Task(ID, description, priority);

                    if (priority < node.priority)
                        node.left = InsertNode(node.left, ID, description, priority);

                    else if (priority > node.priority)
                        node.right = InsertNode(node.right, ID, description, priority);

                    else
                        return node;

                    // Updates node
                    node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));

                    // Balance factor
                    int balance = GetBalance(node);

                    // If the theres is no balance, use the rotations.
                    // Left rotation // may be error in <>
                    if (balance > 1 && priority > node.left.priority)
                        return RightRotation(node);

                    // Right rotation
                    if (balance < -1 && priority < node.right.priority)
                        return LeftRotation(node);

                    // Double left rotation
                    if (balance > 1 && priority > node.left.priority)
                    {
                        node.left = LeftRotation(node.left);
                        return RightRotation(node);
                    }

                    // Double right rotation
                    if (balance < -1 && priority < node.right.priority)
                    {
                        node.right = RightRotation(node.right);
                        return LeftRotation(node);
                    }

                    return node;
                }

                public void DeleteNode(int data)
                {
                    root = RecursiveDelete(root, data);
                }
                private Task RecursiveDelete(Task node, int data)
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
                private int GetMinimal(Task node)
                {
                    int min = node.ID;

                    while (node.left != null)
                    {
                        min = node.left.ID;
                        node = node.left;
                    }
                    return min;
                }


                public void In_Order_Traverse(bool ifInversed)
                {
                    if (!ifInversed)
                    RecursiveTraverse(root);

                    else InverseRecursiveTraverse(root);
                }

                private void RecursiveTraverse(Task node)
                {
                    // By inverting the nodes, it traverses decreasing the values. 
                    if (node != null)
                    {
                        RecursiveTraverse(node.left);
                        Console.Write(node.ID + " ");
                        RecursiveTraverse(node.right);
                    }
                }

                private void InverseRecursiveTraverse(Task node)
                {
                    // By inverting the nodes, it traverses decreasing the values. 
                    if (node != null)
                    {
                        InverseRecursiveTraverse(node.right);
                        Console.Write(node.ID + " ");
                        InverseRecursiveTraverse(node.left);
                    }
                }

                public bool Search(int data)
                {
                    return RecursiveSearch(root, data);
                }

                private bool RecursiveSearch(Task node, int data)
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
            }
        }
    }
}
