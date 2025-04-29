using System.ComponentModel.DataAnnotations;
using HomeBudget.API.Models.Domain.Abstract;
using HomeBudget.API.Models.Domain.Accounts;
using HomeBudget.API.Models.Domain.Budgets;
using HomeBudget.API.Models.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Models.Domain.Expenses
{
    public class Expense : AbstractTransactionBasic
    {
        public List<ExpenseSort> ExpenseSorts { get; } = [];
        public List<Account> Accounts { get; } = [];
        public List<User> Users { get; } = [];
    }
}
