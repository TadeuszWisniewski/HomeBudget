using System.ComponentModel.DataAnnotations;
using HomeBudget.API.Models.Domain.Abstract;
using HomeBudget.API.Models.Domain.Accounts;
using HomeBudget.API.Models.Domain.Debts;
using HomeBudget.API.Models.Domain.Expenses;
using HomeBudget.API.Models.Domain.Incomes;

namespace HomeBudget.API.Models.Domain.Currencies
{
    public class Currency : AbstractDomainBasic
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Sign can't be longer than 10 characters")]
        public string Sign { get; set; } = null!;
        public ICollection<Expense> Expenses { get; } = new List<Expense>();
        public ICollection<Income> Incomes { get; } = new List<Income>();
        public ICollection<Account> Accounts { get; } = new List<Account>();
        public ICollection<Transfer> Transfers { get; } = new List<Transfer>();
        public ICollection<Debt> Debts { get; } = new List<Debt>();

        //public ICollection<Goal> Goals { get; } = new List<Goal>();
        //public ICollection<Saving> Savings { get; } = new List<Saving>();

    }
}
