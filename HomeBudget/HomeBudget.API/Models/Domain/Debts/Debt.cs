using HomeBudget.API.Models.Domain.Abstract;
using HomeBudget.API.Models.Domain.Accounts;
using HomeBudget.API.Models.Domain.Users;

namespace HomeBudget.API.Models.Domain.Debts
{
    public class Debt : AbstractTransactionBasic
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public ICollection<Transfer> Transfers { get; } = new List<Transfer>();
        public List<User> Users { get; } = [];
    }
}
