using HomeBudget.API.Models.Domain.Abstract;
using HomeBudget.API.Models.Domain.Debts;
using HomeBudget.API.Models.Domain.Expenses;
using HomeBudget.API.Models.Domain.Incomes;
using HomeBudget.API.Models.Domain.Users;

namespace HomeBudget.API.Models.Domain.Accounts
{
    public class Account : AbstractTransactionBasic
    {
        public string AccountNumber { get; set; } = string.Empty;
        public List<Expense> Expenses { get; } = [];
        public List<Income> Incomes { get; } = [];
        public List<Transfer> Transfers { get; } = [];
        public List<User> Users { get; } = [];
        public ICollection<Debt> Debts { get; } = new List<Debt>();
    }
}
