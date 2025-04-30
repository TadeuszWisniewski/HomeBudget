using HomeBudget.API.Models.DTO.Abstract;

namespace HomeBudget.API.Models.DTO.Budgets
{
    public class BudgetDuration : AbstractDomainBasic
    {
        public ICollection<Budget> Budgets { get; } = new List<Budget>();
    }
}
