using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TownValidator : AbstractValidator<Town>
    {
        public TownValidator()
        {
            RuleFor(t => t.TownName).NotEmpty();
            RuleFor(t => t.CityId).NotEmpty();
        }
    }
}
