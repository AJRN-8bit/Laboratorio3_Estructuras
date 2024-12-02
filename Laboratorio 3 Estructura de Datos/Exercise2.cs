using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Estructura_de_Datos
{
    internal class Exercise2
    {
        public static void Exercise()
        {
            // Displays a description of the exercise
            Display_Info.ExersiceDescription(2, "Evaluación de Expresiones Booleanas",
                    "Evalua los valores dentro de un árbol binario y mustra su resultado final.");

            // Creation of the bianry tree
            Binary_Tree_Struc.Boolean_Exp_Tree Boolean_BB_Tree = new Binary_Tree_Struc.Boolean_Exp_Tree();

            string[] b1V = { "true", "AND", "false", "OR", "true" };
            string[] b2V = { "true", "OR", "false", "AND", "NOT", "false" };

            // Data insertion to first tree
            Boolean_BB_Tree.root = new Binary_Tree_Struc.Boolean_Exp_Node(b1V[3]); // OR
            Boolean_BB_Tree.root.left = new Binary_Tree_Struc.Boolean_Exp_Node(b1V[1]); // AND
            Boolean_BB_Tree.root.left.left = new Binary_Tree_Struc.Boolean_Exp_Node(b1V[0]); // true
            Boolean_BB_Tree.root.left.right = new Binary_Tree_Struc.Boolean_Exp_Node(b1V[2]); // false

            Boolean_BB_Tree.root.right = new Binary_Tree_Struc.Boolean_Exp_Node(b1V[4]); // true

            Console.WriteLine();
            Console.WriteLine("Arbol binario 1:");
            Console.WriteLine();
            Boolean_BB_Tree.InOrderTraverse(Boolean_BB_Tree.root);
            Console.WriteLine(" = " + ExpressionTree(b1V)); // Evaluates the values



            // Data insertion to second tree
            Boolean_BB_Tree.root = new Binary_Tree_Struc.Boolean_Exp_Node(b2V[3]); // AND
            Boolean_BB_Tree.root.left = new Binary_Tree_Struc.Boolean_Exp_Node(b2V[1]); // OR
            Boolean_BB_Tree.root.left.left = new Binary_Tree_Struc.Boolean_Exp_Node(b2V[0]); // true
            Boolean_BB_Tree.root.left.right = new Binary_Tree_Struc.Boolean_Exp_Node(b2V[2]); // false

            Boolean_BB_Tree.root.right = new Binary_Tree_Struc.Boolean_Exp_Node(b2V[4]); // NOT
            Boolean_BB_Tree.root.right.right = new Binary_Tree_Struc.Boolean_Exp_Node(b2V[5]); // false

            Console.WriteLine();
            Console.WriteLine("Arbol binario 2:");
            Console.WriteLine();
            Boolean_BB_Tree.InOrderTraverse(Boolean_BB_Tree.root);
            Console.WriteLine(" = " + ExpressionTree(b2V)); // Evaluates the values



            // Extra Tree
            string[] b3V = { "true", "OR", "false", "AND", "false" };

            Boolean_BB_Tree.root = new Binary_Tree_Struc.Boolean_Exp_Node(b3V[3]); // AND
            Boolean_BB_Tree.root.left = new Binary_Tree_Struc.Boolean_Exp_Node(b3V[1]); // OR
            Boolean_BB_Tree.root.left.left = new Binary_Tree_Struc.Boolean_Exp_Node(b3V[0]); // true
            Boolean_BB_Tree.root.left.right = new Binary_Tree_Struc.Boolean_Exp_Node(b3V[2]); // false

            Boolean_BB_Tree.root.right = new Binary_Tree_Struc.Boolean_Exp_Node(b3V[4]); // false

            Console.WriteLine();
            Console.WriteLine("Arbol extra:");
            Console.WriteLine("Arbol binario 3:");
            Console.WriteLine();
            Boolean_BB_Tree.InOrderTraverse(Boolean_BB_Tree.root);
            Console.WriteLine(" = " + ExpressionTree(b3V)); // Evaluates the values


            Display_Info.ShowContinue();
        }

        internal class Binary_Tree_Struc
        {
            public class Boolean_Exp_Node
            {
                public string data;
                public Boolean_Exp_Node left;
                public Boolean_Exp_Node right;
                public Boolean_Exp_Node(string data)
                {
                    this.data = data;
                    left = null;
                    right = null;
                }
            }

            // This tree structure is small because it dosent use lot of the other methods.
            public class Boolean_Exp_Tree
            {
                public Boolean_Exp_Node root;
                public Boolean_Exp_Tree()
                {
                    root = null;
                }

                public void InOrderTraverse(Boolean_Exp_Node node)
                {
                    // Left, Root, Right
                    if (node == null) return;
                    InOrderTraverse(node.left); // Traverse the left side
                    Console.Write(node.data + " "); // Goes to the root
                    InOrderTraverse(node.right);  // Traverse the right side
                }
            }
        }



        public static bool ExpressionTree(string[] operand)
        {
            bool bool_result = false;
            bool boolean1 = false;
            bool boolean2 = false;

            // 
            foreach (string operandItem in operand)
            {

                if (operandItem == "true")
                {
                    boolean1 = true;
                }
                if (operandItem == "false")
                {
                    boolean2 = false;
                }

                if (operandItem == "NOT")
                {
                    bool_result = boolean1 != boolean2;
                }
                else if (operandItem == "AND")
                {
                    bool_result = boolean1 && boolean2;
                }
                else if (operandItem == "OR")
                {
                    bool_result = boolean1 || boolean2;
                }

            }
            return bool_result;
        }

    }
}
