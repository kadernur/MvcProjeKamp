using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori Adı boş geçilemez.");

            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez.");

            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın!");
            RuleFor(c => c.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girmeyiniz!");


        }



    }
}
