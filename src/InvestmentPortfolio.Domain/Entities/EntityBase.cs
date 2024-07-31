
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentPortfolio.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        public virtual ValidationResult IsValid()
        {
            throw new NotImplementedException();
        }
    }

}
