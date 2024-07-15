
using FluentValidation.Results;

namespace InvestmentPortfolio.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ValidationResult ValidationResult { get; set; }
        public virtual ValidationResult IsValid()
        {
            throw new NotImplementedException();
        }
    }

}
