using System.ComponentModel.DataAnnotations;
using HomeBudget.API.Models.DTO.Abstract;

namespace HomeBudget.API.Models.DTO.Expenses
{
    public class ExpenseSort : AbstractDomainBasic
    {
        public Guid ExpenseSubsortId { get; set; }
        public ExpenseSubsort ExpenseSubsort { get; set; } = null!;
        public List<Expense> Expenses { get; } = [];
    }
}
