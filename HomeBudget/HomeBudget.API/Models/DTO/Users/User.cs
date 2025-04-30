using System.ComponentModel.DataAnnotations;
using HomeBudget.API.Models.DTO.Abstract;
using HomeBudget.API.Models.DTO.Accounts;
using HomeBudget.API.Models.DTO.Debts;
using HomeBudget.API.Models.DTO.Expenses;
using HomeBudget.API.Models.DTO.Incomes;

namespace HomeBudget.API.Models.DTO.Users
{
    public class User : AbstractDomainBasic
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Surname can't be longer than 50 characters")]
        [MinLength(3, ErrorMessage = "Surname can't be shorter than 3 characters")]
        public string Surname { get; set; } = null!;
        [Required]
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        [MinLength(3, ErrorMessage = "Name can't be shorter than 3 characters")]
        public string Email { get; set; } = null!;
        public List<Account> Accounts { get; } = [];
        public List<Expense> Expenses { get; } = [];
        public List<Income> Incomes { get; } = [];
        public Guid UserTypeId { get; set; }
        public UserType UserTypes { get; set; } = null!;
        public List<Debt> Debts { get; } = [];
        public Guid? CoOperatorId { get; set; }
        public User? CoOperator { get; set; }
        public ICollection<User> Cooperators { get; set; }
    }
}
