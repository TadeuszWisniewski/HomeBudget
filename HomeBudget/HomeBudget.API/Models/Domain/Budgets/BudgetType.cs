using HomeBudget.API.Models.Domain.Abstract;

namespace HomeBudget.API.Models.Domain.Budgets
{
    public class BudgetType: AbstractDomainBasic
    {
        public ICollection<Budget> Budgets { get; } = new List<Budget>();
    }
}
