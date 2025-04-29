using System.ComponentModel.DataAnnotations;
using HomeBudget.API.Models.Domain.Abstract;

namespace HomeBudget.API.Models.Domain.Expenses
{
    public class ExpenseSort : AbstractDomainBasic
    {
        public Guid ExpenseSubsortId { get; set; }
        public ExpenseSubsort ExpenseSubsort { get; set; } = null!;
        public List<Expense> Expenses { get; } = [];
    }
}
