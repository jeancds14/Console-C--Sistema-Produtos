using Produtos.Model;
using Produtos.Service;
using System;

namespace Produtos
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Sistema de Produtos");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Digite o número referente a opção:");
                Console.WriteLine("1 - Criar produto");
                Console.WriteLine("2 - Editar produto");
                Console.WriteLine("3 - Listar todos os produtos");
                Console.WriteLine("4 - Listar um produto");
                Console.WriteLine("5 - Deletar produto");
                string option = Console.ReadLine();

                ProductService productS = new ProductService();
                Product product = new Product();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Nome");
                        string name = Console.ReadLine();

                        Console.WriteLine("Quantidade");
                        int quantCreate = Convert.ToInt32(Console.ReadLine());

                        product.Name = name;
                        product.Quantity = quantCreate;

                        productS.CreateProduct(product);
                        break;
                    case "2":
                        Console.WriteLine("Id do produto");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Quantidade do produto");
                        int quantEdit = Convert.ToInt32(Console.ReadLine());

                        var resultUpdate = productS.UpdateProduct(id, quantEdit);

                        Console.WriteLine($"Produto Nome: {resultUpdate.Name} Quantidade: {resultUpdate.Quantity}");
                        break;
                    case "3":
                        var productsListAll = productS.GetAllProduct();

                        foreach (var item in productsListAll)
                        {
                            Console.WriteLine($"Produto Id: {item.Id} Nome: {item.Name} Quantidade: {item.Quantity}");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Id do produto");
                        int idList = Convert.ToInt32(Console.ReadLine());

                        var productsList = productS.GetProduct(idList);

                        Console.WriteLine($"Produto Nome: {productsList.Name} Quantidade: {productsList.Quantity}");
                        break;
                    case "5":
                        Console.WriteLine("Id do produto");
                        int idDelete = Convert.ToInt32(Console.ReadLine());

                        productS.DeleteProduct(idDelete);
                        break;
                }

                Console.WriteLine("Digite 1 para continuar no sistema ou 2 para sair.");
                exit = Console.ReadLine() == "1" ? false : true;

            }
        }
    }
}
