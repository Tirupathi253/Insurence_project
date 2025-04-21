using InsuranceApp.Models;

namespace InsuranceApp.Repository
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(Payment payment);
    }
}
