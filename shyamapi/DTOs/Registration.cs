namespace WebAPI.DTOs
{
    public class Registration
    {
        
        public string SubmissionURL { get; set; }
        public int SubmitterBEMSID { get; set; }
        public string ContentOwnersBEMSID { get; set; }
        public string IsRestrictedContent { get; set; }
        public string IsBehindWSSO { get; set; }
    }
}
