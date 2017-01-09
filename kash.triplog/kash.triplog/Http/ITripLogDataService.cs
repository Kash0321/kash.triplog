using kash.triplog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kash.triplog.Http
{
    public interface ITripLogDataService
    {
        Task<IList<TripLogEntry>> GetEntriesAsync();

        Task<TripLogEntry> GetEntryAsync(string id);

        Task<TripLogEntry> AddEntryAsync(TripLogEntry entry);

        Task<TripLogEntry> UpdateEntryAsync(TripLogEntry entry);

        Task RemoveEntryAsync(TripLogEntry entry);
    }
}
