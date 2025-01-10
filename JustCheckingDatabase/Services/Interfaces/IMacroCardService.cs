using JustCheckingDatabase.Entities;
namespace JustCheckingDatabase.Services.Interfaces
{
    public interface IMacroCardService
    {
        public Task<List<Macrocard>> GetAllMacrocardsAsync();
        public Task<Macrocard> GetMacrocardAsync(int macrocardId);
        public Task PostMacrocardAsync(Macrocard newMacrocard);
        public Task PutMacrocardAsync(Macrocard updatedMacrocard);
        public Task DeleteMacrocardAsync(int macrocardId);
    }
}
