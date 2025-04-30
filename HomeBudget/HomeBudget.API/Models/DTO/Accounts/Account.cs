using HomeBudget.API.Models.DTO.Abstract;
using HomeBudget.API.Models.DTO.Debts;
using HomeBudget.API.Models.DTO.Expenses;
using HomeBudget.API.Models.DTO.Incomes;
using HomeBudget.API.Models.DTO.Users;

namespace HomeBudget.API.Models.DTO.Accounts
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
