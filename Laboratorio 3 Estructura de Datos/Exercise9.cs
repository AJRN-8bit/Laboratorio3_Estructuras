using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Estructura_de_Datos
{
    internal class Exercise9
    {
        public static void Exercise()
        {
            // Displays a description of the exercise
            Display_Info.ExersiceDescription(9, "Registro de Contactos en un Árbol Binario de Búsqueda",
                "Crear un sistema de registro de contactos utilizando un árbol binario de búsqueda donde los contactos se " +
                "organizan por el nombre.");

            // Creation of tree
            Search_BinaryTree_Struct.ContactTree contactTree = new Search_BinaryTree_Struct.ContactTree();

            // Data insertion
            contactTree.Insert(new Search_BinaryTree_Struct.Contact(9931233452, "   Luz", "   sarmiento.@gmail"));
            contactTree.Insert(new Search_BinaryTree_Struct.Contact(9921234567, "   Avril", "   avrilfos.@gmail"));
            contactTree.Insert(new Search_BinaryTree_Struct.Contact(5521827582, "   Jaris", "   jaris.@gmail"));
            contactTree.Insert(new Search_BinaryTree_Struct.Contact(9923134556, "   Edson", "   edson.@gmail"));
            contactTree.Insert(new Search_BinaryTree_Struct.Contact(2321445643, "   Eily", "   eilyllop.@gmail"));
            contactTree.Insert(new Search_BinaryTree_Struct.Contact(9973123356, "   Emilio", "   celos.@gmail"));

            // Search of people
            Console.WriteLine("Se encuetra jaris?  " + contactTree.Search("jaris"));
            Console.WriteLine("Se encuetra emilio?  " + contactTree.Search("jaris"));
            Console.WriteLine("Se encuetra edson?  " + contactTree.Search("jaris"));
            Console.WriteLine();

            // Alphabetical order
            Console.WriteLine("Orden alfabetico:");
            contactTree.ContactList();

            Display_Info.ShowContinue();

        }


        internal class Search_BinaryTree_Struct
        {
            public class Contact
            {
                public double phone;
                public string name;
                public string email;
                public Contact(double phone, string name, string email)
                {
                    this.phone = phone;
                    this.name = name;
                    this.email = email;
                }

                public override string ToString()
                {
                    return $"{phone} {name} {email}";
                }
            }

            public class Node
            {
                public Contact contact;
                public Node left;
                public Node right;
                public Node(Contact contact)
                {
                    this.contact = contact;
                    left = null;
                    right = null;
                }

            }

            public class ContactTree
            {
                private Node root;
                public ContactTree()
                {
                    root = null;
                }

                public void Insert(Contact contact)
                {
                    root = RecursiveInsertion(root, contact);
                }

                private Node RecursiveInsertion(Node node, Contact contact)
                {
                    if (node == null)
                    {
                        node = new Node(contact);
                        return node;
                    }
                    // The value is a positive if the text is graphically higher or a negative if the text is graphically
                    // lower than the other. This for the alphabethical order.
                    if (contact.name.CompareTo(node.contact.name) < 0)
                    {
                        node.left = RecursiveInsertion(node.left, contact);
                    }
                    else if (contact.name.CompareTo(node.contact.name) > 0)
                    {
                        node.right = RecursiveInsertion(node.right, contact);
                    }
                    return node;
                }

                public bool Search(string name)
                {
                    return RecursiveSearch(root, name);
                }

                private bool RecursiveSearch(Node node, string name)
                {
                    if (node == null)
                    {
                        return false;
                    }

                    // Compares names
                    if (name == node.contact.name.ToLower())
                    {
                        return true;
                    }
                    else if (node.contact.name.CompareTo(node.contact.name) < 0)
                    {
                        return RecursiveSearch(node.left, name);
                    }
                    else if (node.contact.name.CompareTo(node.contact.name) > 0)
                    {
                        return RecursiveSearch(node.right, name);
                    }
                    return false;
                }


                public void ContactList()
                {
                    RecursiveTraverse(root);
                }

                private void RecursiveTraverse(Node node)
                {
                    if (node != null)
                    {
                        RecursiveTraverse(node.left);
                        Console.WriteLine($"{node.contact}");
                        RecursiveTraverse(node.right);
                    }
                }
            }
        }
    }
}
