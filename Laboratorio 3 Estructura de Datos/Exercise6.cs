using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Estructura_de_Datos
{
    internal class Exercise6
    {
        public static void Exercise()
        {
            // Displays a description of the exercise
            Display_Info.ExersiceDescription(6, "Cálculo de Operaciones Matemáticas con Árboles Binarios",
                "Crear un árbol binario para evaluar expresiones matemáticas complejas.");

            // Creation of the bianry tree
            Binary_Tree_Struc.BinaryTree Exp_B_Tree = new Binary_Tree_Struc.BinaryTree();

            // Expression 
            string exp = "3+5*2-4";
            char[] elements = exp.ToCharArray();

            Exp_B_Tree.root = new Binary_Tree_Struc.Operation_Node(elements[3]); // *
            Exp_B_Tree.root.left = new Binary_Tree_Struc.Operation_Node(elements[1]); // +
            Exp_B_Tree.root.right = new Binary_Tree_Struc.Operation_Node(elements[5]); // -
            Exp_B_Tree.root.left.left = new Binary_Tree_Struc.Operation_Node(elements[0]); // 3
            Exp_B_Tree.root.left.right = new Binary_Tree_Struc.Operation_Node(elements[2]); // 5
            Exp_B_Tree.root.right.left = new Binary_Tree_Struc.Operation_Node(elements[4]); // 2
            Exp_B_Tree.root.right.right = new Binary_Tree_Struc.Operation_Node(elements[6]); // 4

            // Show the element in-order and the result
            Exp_B_Tree.InOrderTraverse(Exp_B_Tree.root);
            Console.WriteLine(" = " + ExpressionTree(elements));
            

            Display_Info.ShowContinue();
        }



        internal class Binary_Tree_Struc
        {
            public class Operation_Node
            {
                public char data;
                public Operation_Node left;
                public Operation_Node right;
                public Operation_Node(char data)
                {
                    this.data = data;
                    left = null;
                    right = null;
                }
            }

            // This tree structure is small because it dosent use lot of the other methods.
            public class BinaryTree
            {
                public Operation_Node root;
                public BinaryTree()
                {
                    root = null;
                }

                public void InOrderTraverse(Operation_Node node)
                {
                    // Left, Root, Right
                    if (node == null) return;
                    InOrderTraverse(node.left); // Traverse the left side
                    Console.Write(node.data + " "); // Goes to the root
                    InOrderTraverse(node.right);  // Traverse the right side
                }
            }
        }



        public static double ExpressionTree(char[] expression)
        {
            double result = 0;
            double num1 = 0;
            double num2 = 0;

            // need to be checked
            foreach (char operandItem in expression)
            {

                if (char.IsNumber(operandItem))
                {
                    num1 = operandItem;
                }
                if (char.IsNumber(operandItem))
                {
                    num2 = operandItem;
                }

                if (operandItem == '+')
                {
                    result = num1 + num2;
                }
                else if (operandItem == '*')
                {
                    result = num1 * num2;
                }
                else if (operandItem == '/')
                {
                    result = num1 / num2;
                }
            }
            return result;
        }
    }
}
