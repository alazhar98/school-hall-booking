using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface ISchoolPlanService
    {
        // Plan Areas
        Task<List<PlanArea>> GetAllAreasAsync();
        Task<List<PlanArea>> GetAllPlanAreasAsync();
        Task<PlanArea?> GetPlanAreaByIdAsync(int id);
        Task AddPlanAreaAsync(PlanArea planArea);
        Task UpdatePlanAreaAsync(PlanArea planArea);
        Task DeletePlanAreaAsync(int id);

        // Plan Objectives
        Task<List<PlanObjective>> GetAllObjectivesAsync();
        Task<PlanObjective?> GetPlanObjectiveByIdAsync(int id);
        Task AddPlanObjectiveAsync(PlanObjective planObjective);
        Task UpdatePlanObjectiveAsync(PlanObjective planObjective);
        Task DeletePlanObjectiveAsync(int id);

        // Plan SubObjectives
        Task<List<PlanSubObjective>> GetAllSubObjectivesAsync();
        Task<List<PlanSubObjective>> GetSubObjectivesByObjectiveIdAsync(int objectiveId);
        Task<PlanSubObjective?> GetPlanSubObjectiveByIdAsync(int id);
        Task AddPlanSubObjectiveAsync(PlanSubObjective planSubObjective);
        Task UpdatePlanSubObjectiveAsync(PlanSubObjective planSubObjective);
        Task DeletePlanSubObjectiveAsync(int id);

        // Plan Actions
        Task<List<PlanAction>> GetActionsBySubObjectiveIdAsync(int subObjectiveId);
        Task<PlanAction?> GetPlanActionByIdAsync(int id);
        Task AddPlanActionAsync(PlanAction planAction);
        Task UpdatePlanActionAsync(PlanAction planAction);
        Task DeletePlanActionAsync(int id);

        // Validation
        Task<bool> PlanAreaExistsAsync(string name, int? excludeId = null);
        Task<bool> PlanObjectiveExistsAsync(string objective, int? excludeId = null);
        Task<bool> PlanSubObjectiveExistsAsync(int objectiveId, string area, string subObjective, int? excludeId = null);
        Task<bool> PlanActionExistsAsync(int subObjectiveId, string action, int? excludeId = null);
    }
}
