using BlogPage.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Service.Validations
{
    public class BlogDtoValidator:AbstractValidator<BlogDTO>
    {
        public BlogDtoValidator()
        {
            RuleFor(b =>b.Title).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required");
            RuleFor(b => b.Content).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required");
            RuleFor(b => b.ImagePath).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required");
            RuleFor(b => b.CategoryId).InclusiveBetween(1,int.MaxValue).WithMessage("Required");
        }
    }
}
