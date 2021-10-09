using Core.Utilities.Results;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using System.Linq;
using Core.Utilities.Business;

namespace Business.Concrete
{
    //Bir EntityManager (örneğin ProductManager); kendi dal'ı hariç başka bir dal'ı enjecte edemez.
    //Bunun yerine servis enjekte edilir.
    public class ProductManager : IProductService
    {
        //Constructor injection
        //Bir iş sınıfı başka sınıfları new'lemez.

        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları (Ürün adı en az 2 karakter mi?.....)
            //if ler
            //Yetkisi var mı?
            //return _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            //return _productDal.GetAll(p => p.CategoryId == id);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetais()
        {
            //return _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductDetailed);
        }
        
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result=BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                              CheckIfProductNameExists(product.ProductName),
                              CheckIfCategoryLimitExceded());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.ProductId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll().Count;
            if(result>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
