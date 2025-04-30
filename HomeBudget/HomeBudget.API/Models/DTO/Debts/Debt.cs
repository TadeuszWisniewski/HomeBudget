using HomeBudget.API.Models.DTO.Abstract;
using HomeBudget.API.Models.DTO.Accounts;
using HomeBudget.API.Models.DTO.Users;

namespace HomeBudget.API.Models.DTO.Debts
{
    public class Debt : AbstractTransactionBasic
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public ICollection<Transfer> Transfers { get; } = new List<Transfer>();
        public List<User> Users { get; } = [];
    }
}
