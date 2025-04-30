using HomeBudget.API.Models.DTO.Currencies;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HomeBudget.API.Models.DTO.Abstract
{
    public abstract class AbstractTransactionBasic : AbstractDomainBasic
    {
        [Required]
        [Precision(9, 2)]
        [Range(0.01, 9999999.99, ErrorMessage = "Amount must be between 0.01 and 9999999.99")]
        public decimal Amount { get; set; }
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;
    }
}
