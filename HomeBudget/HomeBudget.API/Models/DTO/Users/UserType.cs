using HomeBudget.API.Models.DTO.Abstract;

namespace HomeBudget.API.Models.DTO.Users
{
    public class UserType : AbstractDomainBasic
    {
        public ICollection<User> Users { get; } = new List<User>();
    }
}
