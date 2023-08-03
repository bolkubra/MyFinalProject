using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValitadionRules.FluentValitadion
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //hangi nesne içinse ona kural yazılır
            RuleFor(p => p.ProductName).NotEmpty();//boş geçilemez
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p=> p.CategoryId==1);
            RuleFor(p => p.ProductName).Must(StartWhithA);
        }

        private bool StartWhithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
