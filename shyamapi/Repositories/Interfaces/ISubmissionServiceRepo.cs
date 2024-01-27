using WebAPI.DTOs;
using WebAPI.Model;

namespace WebAPI.Repositories.Interfaces
{
    public interface ISubmissionServiceRepo
    {
        int GetSumission(int id);

        void UpdateSubmission(RegistrationModel registration);
        void DeleteSubmission(int id);
        void InsertNewSubmission(RegistrationModel registration);
    }
}
