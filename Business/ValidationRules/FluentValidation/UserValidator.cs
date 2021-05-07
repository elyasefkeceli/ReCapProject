using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator :AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(5).WithMessage("password can not be emty");
            RuleFor(u => u.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(u => u.LastName).NotEmpty().MinimumLength(2);
            
        }
    }
}
