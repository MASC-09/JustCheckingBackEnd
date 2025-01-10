using JustCheckingDatabase.Context;
using JustCheckingDatabase.Entities;
using JustCheckingDatabase.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace JustCheckingDatabase.Services
{
    public class MacrocardService : IMacroCardService
    {
        //Member variables
        private JCDEVDBContext _dbContext;

        //Constructor
        public MacrocardService(JCDEVDBContext JCDB_Context)
        {
            _dbContext = JCDB_Context;
        }

        //Member methods
        public async Task<List<Macrocard>> GetAllMacrocardsAsync()
        { 
            return await _dbContext.Macrocards.ToListAsync();
        }

        public async Task<Macrocard> GetMacrocardAsync(int macrocardId)
        {
            return await _dbContext.Macrocards.FindAsync(macrocardId);
            
        }

        public async Task PostMacrocardAsync(Macrocard newMacrocard)
        {
            await _dbContext.Macrocards.AddAsync(newMacrocard);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutMacrocardAsync(Macrocard updatedMacrocard)
        {
            var existingMacrocard= await _dbContext.Macrocards.FindAsync(updatedMacrocard.Id);
            if (existingMacrocard != null)
            {
                _dbContext.Entry<Macrocard>(existingMacrocard).CurrentValues.SetValues(existingMacrocard);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteMacrocardAsync(int macrocardId)
        {
            var existingMacrocard = await _dbContext.Macrocards.FindAsync(macrocardId);
            if (existingMacrocard != null)
            {
               _dbContext.Macrocards.Remove(existingMacrocard);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
