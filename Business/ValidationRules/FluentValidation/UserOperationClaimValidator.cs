using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserOperationClaimValidator : AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            //RuleFor(u => u.OperationClaimId).NotEmpty();
            RuleFor(u => u.UserId).NotEmpty();
        }
    }
}
