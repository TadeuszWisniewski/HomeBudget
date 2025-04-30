using System.ComponentModel.DataAnnotations;
using HomeBudget.API.Models.DTO.Abstract;

namespace HomeBudget.API.Models.DTO.Incomes
{
    public class IncomeSource : AbstractDomainBasic
    {
        public Guid IncomeSubsourceId { get; set; }
        public IncomeSubsource IncomeSubsource { get; set; } = null!;
        public List<Income> Incomes { get; } = [];
    }
}
