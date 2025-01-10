using JustCheckingDatabase.Entities;
using System.Diagnostics.Metrics;

namespace JustCheckingDatabase.Services.Interfaces
{
    public interface IMeasurementService
    {
        /* Async Methods*/
        public Task<List<Measurement>> GetAllUserMeasurementsAsync(int userId);
        public Task<Measurement> GetMeasurementAsync(int measurementId);

        public Task PostNewMeasurementAsync(Measurement newMeasurement);

        public Task PutMeasurementAsync(Measurement measurementUpdated);

        public Task DeleteMeasurementAsync(int measurementId);



    }
}
