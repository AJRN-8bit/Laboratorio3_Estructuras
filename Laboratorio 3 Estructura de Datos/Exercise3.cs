using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Laboratorio_3_Estructura_de_Datos.Exercise5;

namespace Laboratorio_3_Estructura_de_Datos
{
    internal class Exercise3
    {
        public static void Exercise()
        {
            // Displays a description of the exercise
            Display_Info.ExersiceDescription(3, "Árbol Binario de Búsqueda para Inventario de Productos",
               "Implementar un árbol binario de búsqueda para almacenar y organizar productos en un inventario");

            // Creation of the tree
            Search_BinaryTree_Struct.InventoryTree inventoryTree = new Search_BinaryTree_Struct.InventoryTree();

            // Data insertion
            inventoryTree.Insert(1, "Soda", 15.50);
            inventoryTree.Insert(2, "Papel", 23);
            inventoryTree.Insert(3, "Café", 45);
            inventoryTree.Insert(4, "Leche", 30);
            inventoryTree.Insert(5, "Cheetos", 16.50);
            inventoryTree.Insert(6, "Agua", 5);
            inventoryTree.Insert(7, "Baterias", 20);
            inventoryTree.Insert(8, "Playera", 150);
            inventoryTree.Insert(9, "Helado", 60);
            inventoryTree.Insert(10, "Pantalón", 200);

            // Search an specific product using the ID - standby
            Console.WriteLine("Esta el producto ID 2?  " + inventoryTree.Search(2));
            Console.WriteLine("Esta el producto ID 1?  " + inventoryTree.Search(1));
            Console.WriteLine("Esta el producto ID 7?  " + inventoryTree.Search(7));

            // Deletes products
            inventoryTree.Delete(4);
            inventoryTree.Delete(8);
            inventoryTree.Delete(5);
            inventoryTree.Delete(9);

            // Show the ascending order of the prices
            Console.WriteLine();
            Console.WriteLine("Orden ascendente en precio:");
            Console.WriteLine();
            inventoryTree.In_Order_Traverse_ByPrice();

            Display_Info.ShowContinue();


        }

    }

    internal class Search_BinaryTree_Struct
    {
        public class Product
        {
            public int ID;
            public string name;
            public double price;
            public Product left;
            public Product right;
            public Product(int ID, string name, double price)
            {
                this.ID = ID;
                this.name = name;
                this.price = price;
                left = null;
                right = null;
            }
        }

        public class InventoryTree
        {
            private Product root;
            public InventoryTree()
            {
                root = null;
            }

            public void Insert(int ID, string name, double price)
            {
                root = RecursiveInsertion(root, ID, name, price);
            }

            private Product RecursiveInsertion(Product node, int ID, string name, double price)
            {
                if (node == null)
                {
                    node = new Product(ID, name, price);
                    return node;
                }

                if (price < node.price)
                {
                    node.left = RecursiveInsertion(node.left, ID, name, price);
                }
                else if (price > node.price)
                {
                    node.right = RecursiveInsertion(node.right, ID, name, price);
                }
                return node;
            }

            public bool Search(int ID)
            {
                return RecursiveSearch(root, ID);
            }

            private bool RecursiveSearch(Product node, int ID)
            {
                if (node == null)
                {
                    return false;
                }

                if (ID == node.ID)
                {
                    return true;
                }
                else if (ID < node.ID)
                {
                    return RecursiveSearch(node.left, ID);
                }
                else if (ID > node.ID)
                {
                    return RecursiveSearch(node.right, ID);
                }
                return false;
            }

            public void Delete(int ID)
            {
                root = RecursiveDelete(root, ID);
            }

            private Product RecursiveDelete(Product node, int ID)
            {
                if (node == null)
                {
                    return node;
                }

                if (ID < node.ID)
                {
                    node.left = RecursiveDelete(node.left, ID);
                }
                else if (ID > node.ID)
                {
                    node.right = RecursiveDelete(node.right, ID);
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
                    //node.ID = GetMinimal(node.right);
                    node.right = RecursiveDelete(node.right, node.ID);
                }
                return node;
            }
            /*
            private int GetMinimal(Product node)
            {
                int min = node.data;

                while (node.left != null)
                {
                    min = node.left.data;
                    node = node.left;
                }
                return min;
            }
            */
            public void In_Order_Traverse_ByPrice()
            {
                RecursiveTraverse(root);
            }

            private void RecursiveTraverse(Product node)
            {
                if (node != null)
                {
                    RecursiveTraverse(node.left);
                    Console.WriteLine($"{node.ID} {node.name} {node.price}");
                    RecursiveTraverse(node.right);
                }
            }
        }
    }
}
