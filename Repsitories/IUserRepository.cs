using SecondTry.Models;

namespace SecondTry.Repsitories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> AddUser(List<User> user);

    }
}
