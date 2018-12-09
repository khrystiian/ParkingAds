using WebAPI.Controllers.Mapping;

namespace BusinessLogic
{
    public interface IPaymentLogic
    {
        void Base64Pdf(PaymentViewModel payment);
    }
}