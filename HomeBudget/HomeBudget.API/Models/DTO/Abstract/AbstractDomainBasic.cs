using System.ComponentModel.DataAnnotations;

namespace HomeBudget.API.Models.DTO.Abstract
{
    public abstract class AbstractDomainBasic
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name can't be longer than 20 characters")]
        [MinLength(3, ErrorMessage = "Name can't be shorter than 3 characters")]
        public string Name { get; set; } = null!;
        [MaxLength(100, ErrorMessage = "Description can't be longer than 100 characters")]
        public string? Description { get; set; }
    }
}
