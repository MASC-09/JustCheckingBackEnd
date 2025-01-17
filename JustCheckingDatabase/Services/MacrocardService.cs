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

        //get every macro card
        public async Task<List<Macrocard>> GetAllMacrocardsAsync()
        { 
            return await _dbContext.Macrocards.ToListAsync();
        }

        //Get a single macro card associated with macrocardID
        public async Task<Macrocard> GetMacrocardAsync(int macrocardId)
        {
            return await _dbContext.Macrocards.FindAsync(macrocardId);
            
        }

        // Get all the macrocards associated with a user.
        public async Task<List<Macrocard>> GetUserMacrocarsdAsync(int userId)
        {
            // validate user exists
            return await _dbContext.Set<Macrocard>()
                .Where(macrocard => macrocard.UserId == userId)
                .ToListAsync();
        }

        //create a new macrocard
        public async Task PostMacrocardAsync(Macrocard newMacrocard)
        {
            await _dbContext.Macrocards.AddAsync(newMacrocard);
            await _dbContext.SaveChangesAsync();
        }


        //Update a macrocard
        public async Task PutMacrocardAsync(Macrocard updatedMacrocard)
        {
            var existingMacrocard= await _dbContext.Macrocards.FindAsync(updatedMacrocard.Id);
            if (existingMacrocard != null)
            {
                _dbContext.Entry<Macrocard>(existingMacrocard).CurrentValues.SetValues(existingMacrocard);
                await _dbContext.SaveChangesAsync();
            }
        }

        //delete a macrocard
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
