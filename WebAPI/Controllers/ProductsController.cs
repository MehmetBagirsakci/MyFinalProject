using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //[HttpGet]
        //public string Get()
        //{
        //    return "Merhaba";
        //}

        //[HttpGet]
        //public List<Product> Get()
        //{
        //    return new List<Product>
        //    {
        //        new Product{ ProductId=1, ProductName="Elma"},
        //        new Product{ ProductId=2, ProductName="Armut"},
        //        new Product{ ProductId=3, ProductName="Mandalina"}
        //    };
        //}

        //[HttpGet]
        //public List<Product> Get()
        //{
        //   //IoC Container
        //    var result = _productService.GetAll();
        //    return result.Data;
        //}

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //Projelerde güncelleme ve silme için post kullanılır.
        //İstersen güncelleme için htttp put
        //Silme için http delete kullanabilirsin
    }
}
