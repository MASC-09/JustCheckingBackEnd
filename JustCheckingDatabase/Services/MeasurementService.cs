using JustCheckingDatabase.Services.Interfaces;
using JustCheckingDatabase.Context;
using JustCheckingDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace JustCheckingDatabase.Services
{
    public class MeasurementService : IMeasurementService
    {
        //Member variables
        private JCDEVDBContext _dbContext;

        //Constructor
        public MeasurementService(JCDEVDBContext JCDB_Context)
        {
            _dbContext = JCDB_Context;
        }

        public async Task<List<Measurement>> GetAllUserMeasurementsAsync(int userId)
        {
            return await _dbContext.Measurements
                .Where(m => m.UserId == userId)
                .ToListAsync();
        }

        public async Task<Measurement> GetMeasurementAsync(int measurementId)
        {
            return await _dbContext.Measurements.FindAsync(measurementId);
        }

        public async Task PostNewMeasurementAsync(Measurement newMeasurement)
        {
            await _dbContext.Measurements.AddAsync(newMeasurement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutMeasurementAsync(Measurement measurementUpdated)
        {
            var existingMeasurement = await _dbContext.Measurements.FindAsync(measurementUpdated.Id);
            if (existingMeasurement != null)
            {
                _dbContext.Entry<Measurement>(existingMeasurement).CurrentValues.SetValues(existingMeasurement);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteMeasurementAsync(int measurementId)
        {
            var existingMeasurement = await _dbContext.Measurements.FindAsync(measurementId);
            if (existingMeasurement != null)
            {

                _dbContext.Measurements.Remove(existingMeasurement);
                await _dbContext.SaveChangesAsync();
            }

        }
    }
}
