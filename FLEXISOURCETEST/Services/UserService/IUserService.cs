using FLEXISOURCETEST.Models;

namespace FLEXISOURCETEST.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserProfile>> GetAllProfile();
        Task<UserProfile> Post(UserProfile e);
        Task<UserProfile> Put(int Id, UserProfile e);

        Task<UserProfile> GetUser(int Id);
    }
}
