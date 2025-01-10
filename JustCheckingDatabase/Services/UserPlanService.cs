using JustCheckingDatabase.Context;
using JustCheckingDatabase.Entities;
using JustCheckingDatabase.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustCheckingDatabase.Services
{
    public class UserPlanService : IUserPlanService
    {
        //Member variables
        private JCDEVDBContext _dbContext;

        //Constructor
        public UserPlanService(JCDEVDBContext JCDB_Context)
        {
            _dbContext = JCDB_Context;
        }

        public async Task<List<UserPlan>> GetAllUserPlansAsync(int userId)
        {
            return await _dbContext.Set<UserPlan>()
                .Where(up => up.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserPlan> GetUserPlanAsync(int userPlanId)
        {
            var userPlan = await _dbContext.Set<UserPlan>()
                .FirstOrDefaultAsync(up => up.Id == userPlanId);

            if (userPlan == null)
                throw new KeyNotFoundException($"UserPlan with ID {userPlanId} not found.");

            return userPlan;
        }

        public async Task PostNewUserPlanAsync(UserPlan newUserPlan)
        {
            await _dbContext.Set<UserPlan>().AddAsync(newUserPlan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutUserPlanAsync(UserPlan userPlanUpdated)
        {
            var existingUserPlan = await _dbContext.Set<UserPlan>()
                .FirstOrDefaultAsync(up => up.Id == userPlanUpdated.Id);

            if (existingUserPlan == null)
                throw new KeyNotFoundException($"UserPlan with ID {userPlanUpdated.Id} not found.");

            _dbContext.Entry(existingUserPlan).CurrentValues.SetValues(userPlanUpdated);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserPlanAsync(int userPlanId)
        {
            var userPlan = await _dbContext.Set<UserPlan>()
                .FirstOrDefaultAsync(up => up.Id == userPlanId);

            if (userPlan == null)
                throw new KeyNotFoundException($"UserPlan with ID {userPlanId} not found.");

            _dbContext.Set<UserPlan>().Remove(userPlan);
            await _dbContext.SaveChangesAsync();
        }
    }
}
