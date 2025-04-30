using HomeBudget.API.Models.DTO.Abstract;
using HomeBudget.API.Models.DTO.Budgets;

namespace HomeBudget.API.Models.DTO.Expenses
{
    public class ExpenseSubsort : AbstractDomainBasic
    {
        public ExpenseSort? ExpenseSort { get; set; }
        public List<Budget> Budgets { get; } = [];
    }
}
