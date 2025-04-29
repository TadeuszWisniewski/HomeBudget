using HomeBudget.API.Models.Domain.Abstract;
using HomeBudget.API.Models.Domain.Budgets;

namespace HomeBudget.API.Models.Domain.Expenses
{
    public class ExpenseSubsort : AbstractDomainBasic
    {
        public ExpenseSort? ExpenseSort { get; set; }
        public List<Budget> Budgets { get; } = [];
    }
}
