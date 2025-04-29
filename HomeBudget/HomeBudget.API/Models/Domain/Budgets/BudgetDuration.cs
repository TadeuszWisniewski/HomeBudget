using HomeBudget.API.Models.Domain.Abstract;

namespace HomeBudget.API.Models.Domain.Budgets
{
    public class BudgetDuration : AbstractDomainBasic
    {
        public ICollection<Budget> Budgets { get; } = new List<Budget>();
    }
}
