using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter the correct product name.")
                .MinimumLength(1)
                .MaximumLength(50)
                    .WithMessage("Please enter a word between 2 and 50 characters for the product name.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("The stock value of the product cannot be empty.")
                .Must(p => p >= 0)
                    .WithMessage("The stock value of the product cannot be less than 0.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("The price value of the product cannot be empty.")
                .Must(p => p >= 0)
                    .WithMessage("The price value of the product cannot be less than 0.");
        }
    }
}
