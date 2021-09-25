using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryProduct();
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAllByCategoryId(5))
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void InMemoryProduct()
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
