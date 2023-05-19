using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TripStateValidator : AbstractValidator<TripState>
    {
        public TripStateValidator()
        {
            RuleFor(t => t.StateName).NotEmpty();
        }
    }
}
