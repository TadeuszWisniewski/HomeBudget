using System.ComponentModel.DataAnnotations;
using HomeBudget.API.Models.Domain.Abstract;
using HomeBudget.API.Models.Domain.Accounts;
using HomeBudget.API.Models.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Models.Domain.Incomes
{
    public class Income : AbstractTransactionBasic
    {
        public List<IncomeSource> IncomeSources { get; } = [];
        public List<Account> Accounts { get; } = [];
        public List<User> Users { get; } = [];
    }
}
