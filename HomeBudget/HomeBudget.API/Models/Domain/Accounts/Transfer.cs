using HomeBudget.API.Models.Domain.Abstract;
using HomeBudget.API.Models.Domain.Debts;

namespace HomeBudget.API.Models.Domain.Accounts
{
    public class Transfer : AbstractTransactionBasic
    {
        public List<Account> Accounts { get; } = [];
        public Guid? DebtId { get; set; }
        public Debt? Debt { get; set; }
    }
}
