using WebAPI.DTOs;
using WebAPI.Model;
using WebAPI.Repositories.Interfaces;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Repositories.Implementations
{
    public class SubmissionServiceRepo : ISubmissionServiceRepo
    {
        private readonly string _connectionstring;
        // private readonly ILogger _logger;
        public SubmissionServiceRepo(IConfiguration connectionstring)
        {
            _connectionstring = connectionstring.GetConnectionString("DevDb");

        }
        public void DeleteSubmission(int id)
        {
            throw new NotImplementedException();
        }

        public int GetSumission(int id)
        {
            int count = 0;
            try
            {
                using (var connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    var selectQuery = "SELECT COUNT(SubmissionBEMSID) FROM Tbl_Registration WHERE SubmissionBEMSID = @Id";
                    var command = new SqlCommand(selectQuery, connection);
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        count = (int)command.ExecuteScalar();
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {

                // _logger.LogError(ex.InnerException.ToString());
            }
            return count;

        }

        public void InsertNewSubmission(RegistrationModel registration)
        {

            try
            {
                using (var connection = new SqlConnection(_connectionstring))
                {
                    // new to update the columns 
                    connection.Open();
                    var selectQuery = "INSERT INTO Tbl_Registration (ManagerBEMSID, IsRestrictedContent,IsBehindWSSO,SubmissionBEMSID) VALUES (@ManagerBEMSID, @IsRestrictedContent,@IsBehindWSSO,@SubmissionBEMSID)";
                    using (var command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@SubmissionBEMSID", registration.SubmitterBEMSID);
                        command.Parameters.AddWithValue("@ManagerBEMSID", registration.ContentOwnersBEMSID);
                        command.Parameters.AddWithValue("@IsRestrictedContent", registration.IsRestrictedContent);
                        command.Parameters.AddWithValue("@IsBehindWSSO", registration.IsBehindWSSO);
                        command.Parameters.AddWithValue("@SubmissionBEMSID", registration.SubmitterBEMSID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                // _logger.LogError(ex.InnerException.ToString());
            }


        }

        public void UpdateSubmission(RegistrationModel registration)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionstring))
                {
                    // new to update the columns 
                    connection.Open();
                    var selectQuery = "UPDATE Tbl_Registration SET ManagerBEMSID = @ManagerBEMSID, IsRestrictedContent = @IsRestrictedContent,IsBehindWSSO = @IsBehindWSSO WHERE SubmissionBEMSID = @SubmissionBEMSID";
                    using (var command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@SubmissionBEMSID", registration.SubmitterBEMSID);
                        command.Parameters.AddWithValue("@ManagerBEMSID", registration.ContentOwnersBEMSID);
                        command.Parameters.AddWithValue("@IsRestrictedContent", registration.IsRestrictedContent);
                        command.Parameters.AddWithValue("@IsBehindWSSO", registration.IsBehindWSSO);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                //  _logger.LogError(ex.InnerException.ToString());
            }

        }
    }
}
