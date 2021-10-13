using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductGelAll();
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //IResult result = productManager.Add(new Product { ProductName = "A", CategoryId = 3, UnitPrice = 12, UnitsInStock = 22 });
            //Console.WriteLine(result.Message);
        }

        private static void ProductGelAll()
        {
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //Console.WriteLine(productManager.GetAll().Message);
            //foreach (var product in productManager.GetAll().Data)
            //{
            //    Console.WriteLine(product.ProductName + " / " + product.UnitPrice + " / " + product.UnitsInStock);
            //}
        }
    }
}
