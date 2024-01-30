namespace WebAPI.DTOs
{
    public class Registration
    {
        public int SubmitterBEMSID { get; set; }
        public int ContentOwnersBEMSID { get; set; }

        public int IsRestrictedContent { get; set; }
        public int IsBehindWSSO { get; set; }
        public int Issharepoint { get; set; }
    }
}

