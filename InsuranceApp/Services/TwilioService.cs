using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
namespace InsuranceApp.Services
{
    public class TwilioService
    {
        public void SendSms(string toNumber, string message)
        {
            string accountSid = "YOUR_ACCOUNT_SID";
            string authToken = "YOUR_AUTH_TOKEN";
            TwilioClient.Init(accountSid, authToken);

            MessageResource.Create(
                to: new PhoneNumber(toNumber),
                from: new PhoneNumber("YOUR_TWILIO_PHONE"),
                body: message
            );
        }
    }
}
