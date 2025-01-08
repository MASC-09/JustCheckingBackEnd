using JustCheckingDatabase.Services.Interfaces;
using JustCheckingDatabase.Context;
using JustCheckingDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace JustCheckingDatabase.Services
{
    public class UserService : IUserService
    {
        //Member variables
        private JCDEVDBContext _dbContext;

        //Constructor
        public UserService(JCDEVDBContext JCDB_Context)
        {
            _dbContext = JCDB_Context;
        }

        //Member Functions
        /**********Sync Functions**********/

        //get all users
        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users;
        }

        //get a single user
        public User GetUser(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        //delete
        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        //Put
        public void PutUser(User userUpdated)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userUpdated.Id);
            if (user != null)
            {
                _dbContext.Entry<User>(user).CurrentValues.SetValues(user);
                _dbContext.SaveChanges();
            }
        }

        //Post
        public void PostUser(User newUser)
        {
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }


        /**********Async Functions**********/
        public async Task<List<User>> GetAllUserAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }


        public async Task PostUserAsync(User newUser) 
        {
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutUserAsync(User userUpdated) 
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userUpdated.Id);
            if (user != null)
            {
                _dbContext.Entry<User>(user).CurrentValues.SetValues(userUpdated);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int id) 
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _dbContext.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
