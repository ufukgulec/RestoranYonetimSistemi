using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez.");
            RuleFor(x => x.PhoneNumber).MaximumLength(10).MinimumLength(10).Matches(new Regex("\\d")).WithMessage("Geçerli telefon numarası giriniz.");
            RuleFor(x => x.StreetId).NotEmpty().WithMessage("Ürün kategorisi seçiniz.");
        }
    }
}
