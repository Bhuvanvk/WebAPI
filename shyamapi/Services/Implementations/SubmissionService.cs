using WebAPI.DTOs;
using WebAPI.Model;
using WebAPI.Repositories.Interfaces;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Implementations
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionServiceRepo _submissionServiceRepo;
        public SubmissionService(ISubmissionServiceRepo submissionServiceRepo) {
            _submissionServiceRepo = submissionServiceRepo;
        }
        public void DeleteSubmission(int id)
        {
            throw new NotImplementedException();
        }

        public int GetSumission(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertNewSubmission(RegistrationModel registration)
        {
            int resultCount=0;
            if (registration!=null)
            {
                resultCount=_submissionServiceRepo.GetSumission(registration.SubmitterBEMSID);
            }
            else
            {
                return false;
            }
            try
            {
                if (resultCount > 0)
                {
                    _submissionServiceRepo.UpdateSubmission(registration);
                    return true;
                }
                else
                {
                    _submissionServiceRepo.InsertNewSubmission(registration);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
           
              
        }

        public void UpdateSubmission(RegistrationModel registration)
        {
            throw new NotImplementedException();
        }
    }
}
