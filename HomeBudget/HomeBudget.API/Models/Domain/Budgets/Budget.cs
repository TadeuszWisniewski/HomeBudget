using HomeBudget.API.Models.Domain.Abstract;
using HomeBudget.API.Models.Domain.Expenses;

namespace HomeBudget.API.Models.Domain.Budgets
{
    public class Budget : AbstractTransactionBasic
    {
        public Guid BudgetTypeId { get; set; }
        public BudgetType BudgetType { get; set; } = null!;
        public Guid BudgetDurationId { get; set; }
        public BudgetDuration BudgetDuration { get; set; } = null!;
        public List<ExpenseSubsort> ExpenseSubsorts { get; } = [];
    }
}
