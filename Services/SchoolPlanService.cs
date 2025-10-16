using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class SchoolPlanService : ISchoolPlanService
    {
        private readonly BookingDbContext _context;

        public SchoolPlanService(BookingDbContext context)
        {
            _context = context;
        }

        // Plan Areas
        public async Task<List<PlanArea>> GetAllAreasAsync()
        {
            return await _context.PlanAreas
                                 .Where(pa => pa.IsActive)
                                 .OrderBy(pa => pa.Name)
                                 .ToListAsync();
        }

        public async Task<List<PlanArea>> GetAllPlanAreasAsync()
        {
            return await _context.PlanAreas
                                 .Where(pa => pa.IsActive)
                                 .Include(pa => pa.Objectives.Where(o => o.IsActive))
                                 .OrderBy(pa => pa.Name)
                                 .ToListAsync();
        }

        public async Task<PlanArea?> GetPlanAreaByIdAsync(int id)
        {
            return await _context.PlanAreas
                                 .Include(pa => pa.Objectives.Where(o => o.IsActive))
                                 .FirstOrDefaultAsync(pa => pa.Id == id);
        }

        public async Task AddPlanAreaAsync(PlanArea planArea)
        {
            planArea.CreatedAt = DateTime.Now;
            _context.PlanAreas.Add(planArea);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlanAreaAsync(PlanArea planArea)
        {
            var existingArea = await _context.PlanAreas.FindAsync(planArea.Id);
            if (existingArea != null)
            {
                existingArea.Name = planArea.Name;
                existingArea.IsActive = planArea.IsActive;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlanAreaAsync(int id)
        {
            var planArea = await _context.PlanAreas.FindAsync(id);
            if (planArea != null)
            {
                _context.PlanAreas.Remove(planArea);
                await _context.SaveChangesAsync();
            }
        }

        // Plan Objectives
        public async Task<List<PlanObjective>> GetAllObjectivesAsync()
        {
            return await _context.PlanObjectives
                                 .Where(po => po.IsActive)
                                 .Include(po => po.SubObjectives.Where(so => so.IsActive))
                                 .OrderBy(po => po.Objective)
                                 .ToListAsync();
        }

        public async Task<PlanObjective?> GetPlanObjectiveByIdAsync(int id)
        {
            return await _context.PlanObjectives
                                 .Include(po => po.SubObjectives.Where(so => so.IsActive))
                                 .FirstOrDefaultAsync(po => po.Id == id);
        }

        public async Task<PlanObjective> AddPlanObjectiveAsync(PlanObjective planObjective)
        {
            planObjective.CreatedAt = DateTime.Now;
            _context.PlanObjectives.Add(planObjective);
            await _context.SaveChangesAsync();
            return planObjective;
        }

        public async Task UpdatePlanObjectiveAsync(PlanObjective planObjective)
        {
            var existingObjective = await _context.PlanObjectives.FindAsync(planObjective.Id);
            if (existingObjective != null)
            {
                existingObjective.Objective = planObjective.Objective;
                existingObjective.IsActive = planObjective.IsActive;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlanObjectiveAsync(int id)
        {
            var planObjective = await _context.PlanObjectives.FindAsync(id);
            if (planObjective != null)
            {
                _context.PlanObjectives.Remove(planObjective);
                await _context.SaveChangesAsync();
            }
        }

        // Plan SubObjectives
        public async Task<List<PlanSubObjective>> GetAllSubObjectivesAsync()
        {
            return await _context.PlanSubObjectives
                                 .Where(so => so.IsActive)
                                 .Include(so => so.Actions.Where(a => a.IsActive))
                                 .OrderBy(so => so.Area)
                                 .ThenBy(so => so.SubObjective)
                                 .ToListAsync();
        }

        public async Task<List<PlanSubObjective>> GetSubObjectivesByObjectiveIdAsync(int objectiveId)
        {
            return await _context.PlanSubObjectives
                                 .Where(so => so.PlanObjectiveId == objectiveId && so.IsActive)
                                 .Include(so => so.Actions.Where(a => a.IsActive))
                                 .OrderBy(so => so.Area)
                                 .ThenBy(so => so.SubObjective)
                                 .ToListAsync();
        }

        public async Task<PlanSubObjective?> GetPlanSubObjectiveByIdAsync(int id)
        {
            return await _context.PlanSubObjectives
                                 .Include(so => so.Actions.Where(a => a.IsActive))
                                 .FirstOrDefaultAsync(so => so.Id == id);
        }

        public async Task AddPlanSubObjectiveAsync(PlanSubObjective planSubObjective)
        {
            planSubObjective.CreatedAt = DateTime.Now;
            _context.PlanSubObjectives.Add(planSubObjective);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlanSubObjectiveAsync(PlanSubObjective planSubObjective)
        {
            var existingSubObjective = await _context.PlanSubObjectives.FindAsync(planSubObjective.Id);
            if (existingSubObjective != null)
            {
                existingSubObjective.Area = planSubObjective.Area;
                existingSubObjective.SubObjective = planSubObjective.SubObjective;
                existingSubObjective.IsActive = planSubObjective.IsActive;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlanSubObjectiveAsync(int id)
        {
            var planSubObjective = await _context.PlanSubObjectives.FindAsync(id);
            if (planSubObjective != null)
            {
                _context.PlanSubObjectives.Remove(planSubObjective);
                await _context.SaveChangesAsync();
            }
        }

        // Plan Actions
        public async Task<List<PlanAction>> GetActionsBySubObjectiveIdAsync(int subObjectiveId)
        {
            return await _context.PlanActions
                                 .Where(pa => pa.PlanSubObjectiveId == subObjectiveId && pa.IsActive)
                                 .OrderBy(pa => pa.Action)
                                 .ToListAsync();
        }

        public async Task<PlanAction?> GetPlanActionByIdAsync(int id)
        {
            return await _context.PlanActions.FindAsync(id);
        }

        public async Task AddPlanActionAsync(PlanAction planAction)
        {
            planAction.CreatedAt = DateTime.Now;
            _context.PlanActions.Add(planAction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlanActionAsync(PlanAction planAction)
        {
            var existingAction = await _context.PlanActions.FindAsync(planAction.Id);
            if (existingAction != null)
            {
                existingAction.Action = planAction.Action;
                existingAction.TimePeriod = planAction.TimePeriod;
                existingAction.Executor = planAction.Executor;
                existingAction.IsExecuted = planAction.IsExecuted;
                existingAction.Notes = planAction.Notes;
                existingAction.IsActive = planAction.IsActive;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlanActionAsync(int id)
        {
            var planAction = await _context.PlanActions.FindAsync(id);
            if (planAction != null)
            {
                _context.PlanActions.Remove(planAction);
                await _context.SaveChangesAsync();
            }
        }

        // Validation
        public async Task<bool> PlanAreaExistsAsync(string name, int? excludeId = null)
        {
            return await _context.PlanAreas
                                 .AnyAsync(pa => pa.Name == name && pa.Id != excludeId);
        }

        public async Task<bool> PlanObjectiveExistsAsync(string objective, int? excludeId = null)
        {
            return await _context.PlanObjectives
                                 .AnyAsync(po => po.Objective == objective && po.Id != excludeId);
        }

        public async Task<bool> PlanSubObjectiveExistsAsync(int objectiveId, string area, string subObjective, int? excludeId = null)
        {
            return await _context.PlanSubObjectives
                                 .AnyAsync(so => so.PlanObjectiveId == objectiveId && 
                                                so.Area == area && 
                                                so.SubObjective == subObjective && 
                                                so.Id != excludeId);
        }

        public async Task<bool> PlanActionExistsAsync(int subObjectiveId, string action, int? excludeId = null)
        {
            return await _context.PlanActions
                                 .AnyAsync(pa => pa.PlanSubObjectiveId == subObjectiveId && 
                                                pa.Action == action && 
                                                pa.Id != excludeId);
        }
    }
}
