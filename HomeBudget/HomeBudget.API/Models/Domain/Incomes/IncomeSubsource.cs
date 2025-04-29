using HomeBudget.API.Models.Domain.Abstract;

namespace HomeBudget.API.Models.Domain.Incomes
{
    public class IncomeSubsource : AbstractDomainBasic
    {
        public IncomeSource? IncomeSource { get; set; }
    }
}
