using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface ISurveyRepository
    {
        Task<Survey> AddNewSurvey(Survey survey);
        Task<IEnumerable<Survey>> GetAllSurveyAsync();
        Task<Survey?> GetSurveyByIdAsync(Guid id);
        Task<Survey?> GetSurveyByNameAsync(string surveyName);
        Task DeleteSurveyByIdAsync(Guid id);
        Task UpdateSurveyAsync(Survey survey);
    }
}
