using System.ComponentModel.DataAnnotations;
using HomeBudget.API.Models.DTO.Abstract;
using HomeBudget.API.Models.DTO.Accounts;
using HomeBudget.API.Models.DTO.Budgets;
using HomeBudget.API.Models.DTO.Users;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Models.DTO.Expenses
{
    public class Expense : AbstractTransactionBasic
    {
        public List<ExpenseSort> ExpenseSorts { get; } = [];
        public List<Account> Accounts { get; } = [];
        public List<User> Users { get; } = [];
    }
}
