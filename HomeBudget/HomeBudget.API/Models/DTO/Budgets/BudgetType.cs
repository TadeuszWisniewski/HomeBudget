using HomeBudget.API.Models.DTO.Abstract;

namespace HomeBudget.API.Models.DTO.Budgets
{
    public class BudgetType: AbstractDomainBasic
    {
        public ICollection<Budget> Budgets { get; } = new List<Budget>();
    }
}
