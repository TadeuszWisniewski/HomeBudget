using HomeBudget.API.Models.DTO.Abstract;
using HomeBudget.API.Models.DTO.Debts;

namespace HomeBudget.API.Models.DTO.Accounts
{
    public class Transfer : AbstractTransactionBasic
    {
        public List<Account> Accounts { get; } = [];
        public Guid? DebtId { get; set; }
        public Debt? Debt { get; set; }
    }
}
