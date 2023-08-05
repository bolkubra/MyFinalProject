using Core.Utilities.Results;
using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validetor)
        {
            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
    
}

