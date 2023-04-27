using FluentValidation;

namespace dotnet.Features.Users.GetById
{
    public class ValidationCollection : AbstractValidator<QuerryRequest>
    {
        public ValidationCollection()
        {
            this.RuleFor(r => r.id)
                .NotEqual(0)
                .WithMessage("id can not be zero");
        }
    }
}
