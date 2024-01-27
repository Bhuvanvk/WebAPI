using WebAPI.DTOs;
using WebAPI.Model;

namespace WebAPI.Services.Interfaces
{
    public interface ISubmissionService
    {
       int GetSumission(int id);
  
         void UpdateSubmission(RegistrationModel registration);
        void DeleteSubmission(int id);
        bool InsertNewSubmission(RegistrationModel registration);
        
    }
}
