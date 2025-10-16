using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class DutyScheduleService : IDutyScheduleService
    {
        private readonly BookingDbContext _db;

        public DutyScheduleService(BookingDbContext db)
        {
            _db = db;
        }

        public async Task<List<DutyScheduleItem>> GetScheduleAsync()
        {
            return await _db.DutyScheduleItems
                .AsNoTracking()
                .OrderBy(x => x.Day)
                .ThenBy(x => x.Column)
                .ThenBy(x => x.Row)
                .ToListAsync();
        }

        public async Task SaveScheduleAsync(List<DutyScheduleItem> scheduleItems)
        {
            foreach (var incoming in scheduleItems)
            {
                var existing = await _db.DutyScheduleItems
                    .FirstOrDefaultAsync(x => x.Day == incoming.Day && x.Column == incoming.Column && x.Row == incoming.Row);

                var names = incoming.TeacherNames?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(names))
                {
                    // Empty -> delete existing if any
                    if (existing != null)
                    {
                        _db.DutyScheduleItems.Remove(existing);
                    }
                    continue;
                }

                if (existing == null)
                {
                    incoming.CreatedAt = DateTime.UtcNow;
                    incoming.UpdatedAt = DateTime.UtcNow;
                    _db.DutyScheduleItems.Add(incoming);
                }
                else
                {
                    existing.TeacherNames = names;
                    existing.UpdatedAt = DateTime.UtcNow;
                }
            }

            await _db.SaveChangesAsync();
        }

        public async Task<DutyScheduleItem?> GetScheduleItemAsync(int id)
        {
            return await _db.DutyScheduleItems.FindAsync(id);
        }

        public async Task DeleteScheduleItemAsync(int id)
        {
            var item = await _db.DutyScheduleItems.FindAsync(id);
            if (item != null)
            {
                _db.DutyScheduleItems.Remove(item);
                await _db.SaveChangesAsync();
            }
        }
    }
}
