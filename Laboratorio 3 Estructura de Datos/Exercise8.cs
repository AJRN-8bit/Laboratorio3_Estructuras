using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_Estructura_de_Datos
{
    internal class Exercise8
    {
        public static void Exercise()
        {
            // Displays a description of the exercise
            Display_Info.ExersiceDescription(8, "Árbol de Categorías de Productos",
                "Organizar productos en un árbol de categorías.");

            // Creation of the tree
            ProCat_Binary_Tree.BinaryTree binaryTree = new ProCat_Binary_Tree.BinaryTree();

            // Sets the categories
            List<string> Electronica = new List<string> {"Laptop", "Gaming"};
            List<string> Ropa = new List<string> {"Gucci", "Tela", "Azul"};
            List<string> Electrodomésticos = new List<string> {"Refrigerador", "Licuadora"};

            // Data insertion
            binaryTree.Insert("      Electronica        ", new ProCat_Binary_Tree.Product("Lenovo 84G        ", 6000), Electronica);
            binaryTree.Insert("      Ropa               ", new ProCat_Binary_Tree.Product("Gucci Playera     ", 8000), Ropa);
            binaryTree.Insert("      Electrodomésticos  ", new ProCat_Binary_Tree.Product("Vitamix XT        ", 4000), Electrodomésticos);
            binaryTree.Insert("     Electrodomésticos  ", new ProCat_Binary_Tree.Product("Samsung XL34SR    ", 24000), Electrodomésticos);

            // Shows the products and details
            Console.WriteLine("    Producto    |  Precio  |     Categoria     |    Subcategorias ");
            Console.WriteLine();
            binaryTree.InOrderTraverse(binaryTree.root);

            //binaryTree.Search("Ropa");

        }



        internal class ProCat_Binary_Tree
        {
            public class Category
            {
                public string name;
                public Product product;
                public List<string> subcategories;
                public Category left;
                public Category right;
                public Category(string name, Product product, List<string> subcategories)
                {
                    this.name = name;
                    this.product = product;
                    this.subcategories = subcategories;
                    left = null;
                    right = null;
                }
            }

            public class Product
            {
                public string name;
                public double price;
                public Product(string name, double price)
                {
                    this.name = name;
                    this.price = price;
                }
                public override string ToString()
                {
                    return $"{name}  |  {price}";
                }
            }


            public class BinaryTree
            {
                public Category root;
                public BinaryTree()
                {
                    root = null;
                }
                public void Insert(string name, Product product, List<string> subcategories)
                {
                    root = RecursiveInsertion(root, name, product, subcategories);
                    // poner valores manualmente root.left.left = Value;
                }

                private Category RecursiveInsertion(Category node, string name, Product product, List<string> subcategories)
                {
                    if (node == null)
                    {
                        return new Category(name, product, subcategories);
                    }

                    // Adds the left side if it is empty
                    if (node.left == null)
                    {
                        node.left = new Category(name, product, subcategories);
                    }

                    // Adds the left side if it is empty
                    else if (node.right == null)
                    {
                        node.right = new Category(name, product, subcategories);
                    }

                    else
                    {
                        // If both sides are full, it creates another path
                        RecursiveInsertion(node.left, name, product, subcategories);
                    }
                    return node;
                }

                /*
                public void Search(string name)
                {
                    RecursiveSearch(root, name);
                }

                private void RecursiveSearch(Category node, string name)
                {
                    if (node == null)
                    {
                        Console.WriteLine("Categoria no existente o sin producto.");
                    }

                    if (name == node.name)
                    {
                        Console.WriteLine($"{node.product.name}");
                        RecursiveSearch(node, name);
                    }
                    else
                    {
                        RecursiveSearch(node.left, name);
                        RecursiveSearch(node.right, name);
                    }
                }
                */

                public void InOrderTraverse(Category node)
                {
                    // Left, Root, Right
                    if (node == null) return;

                    string sub = string.Join(" ", node.subcategories);
                    InOrderTraverse(node.left); // Traverse the left side
                    Console.WriteLine($"{node.product.name} {node.product.price} {node.name} {sub} "); // Goes to the root
                    InOrderTraverse(node.right);  // Traverse the right side
                }
            }
        }
    }
}
