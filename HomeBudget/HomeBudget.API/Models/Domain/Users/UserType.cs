using HomeBudget.API.Models.Domain.Abstract;

namespace HomeBudget.API.Models.Domain.Users
{
    public class UserType : AbstractDomainBasic
    {
        public ICollection<User> Users { get; } = new List<User>();
    }
}
