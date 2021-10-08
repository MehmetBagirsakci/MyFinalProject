using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //DTO lar içinde Validator yazabilirsiniz.
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //FluentValidation hata mesajlarını Türkçe olarak verebiliyor.
            //Türkçe dil desteği mevcut.
            //Ancak istersek kendi hata mesajımızı kendimizde yazabiliriz.
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //1 nolu categorideki ürünler için fiyat en az 10tl olsun
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            //Hata mesajını kendimiz yazmak istersek
            RuleFor(p => p.ProductName).MaximumLength(15).WithMessage("Ürün adı en fazla 15 karekter olabilir.");
            //ürünlerin ismi A ile başlamalı gibi bir kural
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı.");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); //A ile başlıyorsa true döner.
        }
    }
}
//Ctrl + K  Ctrl + D kodları hizalar.