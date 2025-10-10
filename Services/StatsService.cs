using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class StatsService : IStatsService
    {
        private readonly BookingDbContext _db;

        public StatsService(BookingDbContext db)
        {
            _db = db;
        }

        public Task<List<StaffStatistic>> GetStaffAsync() => _db.StaffStatistics.AsNoTracking().ToListAsync();
        public Task<StaffStatistic?> GetStaffByIdAsync(int id) => _db.StaffStatistics.FindAsync(id).AsTask();
        public async Task<StaffStatistic> AddStaffAsync(StaffStatistic item)
        {
            _db.StaffStatistics.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }
        public async Task UpdateStaffAsync(StaffStatistic item)
        {
            var existing = await _db.StaffStatistics.FindAsync(item.Id);
            if (existing == null) throw new KeyNotFoundException();
            existing.Role = item.Role;
            existing.Count = item.Count;
            existing.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }
        public async Task DeleteStaffAsync(int id)
        {
            var existing = await _db.StaffStatistics.FindAsync(id);
            if (existing != null)
            {
                _db.StaffStatistics.Remove(existing);
                await _db.SaveChangesAsync();
            }
        }

        public async Task UpsertStaffBulkAsync(List<StaffStatistic> items)
        {
            // Normalize input
            foreach (var i in items)
            {
                if (i.Count < 0) i.Count = 0;
            }

            // 0) Purge any invalid rows (Role == 0 or not defined in StaffRole)
            var allRowsForValidation = await _db.StaffStatistics.ToListAsync();
            var invalidRows = allRowsForValidation
                .Where(s => !Enum.IsDefined(typeof(StaffRole), s.Role))
                .ToList();
            if (invalidRows.Count > 0)
            {
                _db.StaffStatistics.RemoveRange(invalidRows);
                await _db.SaveChangesAsync();
            }

            // 1) Load all existing rows
            var allExisting = await _db.StaffStatistics.ToListAsync();

            // 2) Remove duplicates in DB (keep the most recent per role)
            var duplicates = allExisting
                .GroupBy(s => s.Role)
                .SelectMany(g => g
                    .OrderByDescending(x => x.UpdatedAt ?? x.CreatedAt)
                    .Skip(1))
                .ToList();

            if (duplicates.Count > 0)
            {
                _db.StaffStatistics.RemoveRange(duplicates);
                await _db.SaveChangesAsync();
            }

            // 3) Build a safe lookup for remaining rows (one per role)
            var canonicalList = await _db.StaffStatistics.ToListAsync();
            var existingByRole = new Dictionary<StaffRole, StaffStatistic>();
            foreach (var row in canonicalList)
            {
                if (!existingByRole.TryGetValue(row.Role, out var current))
                {
                    existingByRole[row.Role] = row;
                }
                else
                {
                    // In case any duplicates slipped through, prefer the newest
                    var preferred = ((row.UpdatedAt ?? row.CreatedAt) >= (current.UpdatedAt ?? current.CreatedAt)) ? row : current;
                    existingByRole[row.Role] = preferred;
                }
            }

            // 4) Upsert per role (skip any invalid roles just in case)
            foreach (var item in items)
            {
                if (!Enum.IsDefined(typeof(StaffRole), item.Role))
                {
                    continue;
                }

                if (existingByRole.TryGetValue(item.Role, out var existing))
                {
                    existing.Count = item.Count;
                    existing.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    _db.StaffStatistics.Add(new StaffStatistic
                    {
                        Role = item.Role,
                        Count = item.Count,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            await _db.SaveChangesAsync();
        }

        public Task<List<RegularStudentStatistic>> GetRegularStudentsAsync() => _db.RegularStudentStatistics.AsNoTracking().ToListAsync();
        public Task<RegularStudentStatistic?> GetRegularStudentByIdAsync(int id) => _db.RegularStudentStatistics.FindAsync(id).AsTask();
        public async Task<RegularStudentStatistic> AddRegularStudentAsync(RegularStudentStatistic item)
        {
            _db.RegularStudentStatistics.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }
        public async Task UpdateRegularStudentAsync(RegularStudentStatistic item)
        {
            var existing = await _db.RegularStudentStatistics.FindAsync(item.Id);
            if (existing == null) throw new KeyNotFoundException();
            existing.Division = item.Division;
            existing.Count = item.Count;
            existing.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }
        public async Task DeleteRegularStudentAsync(int id)
        {
            var existing = await _db.RegularStudentStatistics.FindAsync(id);
            if (existing != null)
            {
                _db.RegularStudentStatistics.Remove(existing);
                await _db.SaveChangesAsync();
            }
        }

        public Task<List<HearingImpairedStudentStatistic>> GetHearingImpairedAsync() => _db.HearingImpairedStudentStatistics.AsNoTracking().ToListAsync();
        public Task<HearingImpairedStudentStatistic?> GetHearingImpairedByIdAsync(int id) => _db.HearingImpairedStudentStatistics.FindAsync(id).AsTask();
        public async Task<HearingImpairedStudentStatistic> AddHearingImpairedAsync(HearingImpairedStudentStatistic item)
        {
            _db.HearingImpairedStudentStatistics.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }
        public async Task UpdateHearingImpairedAsync(HearingImpairedStudentStatistic item)
        {
            var existing = await _db.HearingImpairedStudentStatistics.FindAsync(item.Id);
            if (existing == null) throw new KeyNotFoundException();
            existing.Grade = item.Grade;
            existing.Count = item.Count;
            existing.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }
        public async Task DeleteHearingImpairedAsync(int id)
        {
            var existing = await _db.HearingImpairedStudentStatistics.FindAsync(id);
            if (existing != null)
            {
                _db.HearingImpairedStudentStatistics.Remove(existing);
                await _db.SaveChangesAsync();
            }
        }
    }
}


