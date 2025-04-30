using HomeBudget.API.Models.DTO.Abstract;

namespace HomeBudget.API.Models.DTO.Incomes
{
    public class IncomeSubsource : AbstractDomainBasic
    {
        public IncomeSource? IncomeSource { get; set; }
    }
}
