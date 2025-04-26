namespace InsuranceApp.Models
{
    public class PremiumInputModel
    {
        public string PolicyType { get; set; }
        public int Age { get; set; }
        public decimal CoverageAmount { get; set; }
        public int TenureYears { get; set; }
        public decimal EstimatedPremium { get; set; }
    }

}
