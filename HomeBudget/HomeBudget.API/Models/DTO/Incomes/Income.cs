using System.ComponentModel.DataAnnotations;
using HomeBudget.API.Models.DTO.Abstract;
using HomeBudget.API.Models.DTO.Accounts;
using HomeBudget.API.Models.DTO.Users;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Models.DTO.Incomes
{
    public class Income : AbstractTransactionBasic
    {
        public List<IncomeSource> IncomeSources { get; } = [];
        public List<Account> Accounts { get; } = [];
        public List<User> Users { get; } = [];
    }
}
