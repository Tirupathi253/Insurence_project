using InsuranceApp.Models;

namespace InsuranceApp.Repository
{
    public class PaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(Payment payment)
        {
            // Simulate Payment Processing
            return true;
        }
    }
}
