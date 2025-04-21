namespace InsuranceApp.Models
{
    public class ClaimModel
    {
        public int CustomerId { get; set; }
        public int PolicyId { get; set; }
        public string Reason { get; set; }
    }
}
