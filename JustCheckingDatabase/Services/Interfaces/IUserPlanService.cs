using JustCheckingDatabase.Entities;

namespace JustCheckingDatabase.Services.Interfaces
{
    public interface IUserPlanService
    {
        /* Async Methods*/
        public Task<List<UserPlan>> GetAllUserPlansAsync(int userId);
        public Task<UserPlan> GetUserPlanAsync(int userPlanId);

        public Task PostNewUserPlanAsync(UserPlan newUserPlan);

        public Task PutUserPlanAsync(UserPlan UserPlanUpdated);

        public Task DeleteUserPlanAsync(int userPlanId);
    }
}
