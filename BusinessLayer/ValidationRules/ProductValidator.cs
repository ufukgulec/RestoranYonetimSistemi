using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Ürün kategorisi seçiniz.");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("100 Karakterden fazla giriş yapmayınız.");
        }
    }
}
