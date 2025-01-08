using JustCheckingDatabase.Entities;

namespace JustCheckingDatabase.Services.Interfaces
{
    public interface IUserService
    {
        /* Sync Methods*/
        //get all users
        public IEnumerable<User> GetAllUsers();

        //get a single user
        public User GetUser(int id);

        //delete
        public void DeleteUser(int id);

        //Put
        public void PutUser(User userUpdated);

        //Post
        public void PostUser(User newUser);

        /* Async Methods*/
        public Task<List<User>> GetAllUserAsync();
        public Task<User> GetUserAsync(int id);

        public Task PostUserAsync(User newUser);

        public Task PutUserAsync(User userUpdated);

        public Task DeleteUserAsync(int id);

    }
}
