using System;
using System.IO;
using WebAPI.Controllers.Mapping;

namespace BusinessLogic
{
    public class PaymentLogic
    {
        public void Base64Image(PaymentViewModel payment)
        {
            
            byte[] bytes = Convert.FromBase64String(payment.base64StringReceipt);
            File.WriteAllBytes(@"C:\Users\andyc\Desktop\pdfFileName.pdf", bytes);
        }
    }
}
