using BusinessLogic.EmailImpl;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Models;
using System;
using System.IO;
using WebAPI.Controllers.Mapping;


namespace BusinessLogic
{
    public class PaymentLogic: IPaymentLogic
    {
        public void Base64Pdf(PaymentViewModel payment)
        {
            var rbImpl = new RabbitMqImpl();
            byte[] bytes;
            byte[] imageBytes = Convert.FromBase64String(payment.base64StringReceipt.Replace("data:image/png;base64,", ""));
            var image = Image.GetInstance(imageBytes);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                document.Add(image);
                document.Close();
                bytes = memoryStream.ToArray();
                memoryStream.Close();
                rbImpl.AddMessageToQueue(new Payment { Base64Receipt = bytes });
            }
        }
    }
}
