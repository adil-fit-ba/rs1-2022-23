using System.Net;
using System.Net.Mail;
using RestSharp;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FIT_Api_Examples.Helper
{
    public class MyEmailSender
    {
        public static async Task posalji()
        {
            /*
                        var apiKey = "SG.rVnUNPzeQ8eLewx5nR_yjw.lL13NWmBJeXWUCYrXEge5UPdR1ljRxUL5w1Q3iJiJWg";
                        var client = new SendGridClient(apiKey);
                        var from = new EmailAddress("adil@edu.fit.ba", "Adil Joldic");
                        var subject = "Sending with SendGrid is Fun";
                        var to = new EmailAddress("adil.joldic@gmail.com", "Example User");
                        var plainTextContent = "and easy to do anywhere, even with C#";
                        var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                        var response = await client.SendEmailAsync(msg);
                        var r = response.Body.ToString();*/
            /*
            var client = new RestClient("https://rapidprod-sendgrid-v1.p.rapidapi.com/mail/send");
            
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-RapidAPI-Key", "0917933485mshe1005a8ece50464p18b5fajsn281af234aaed");
            request.AddHeader("X-RapidAPI-Host", "rapidprod-sendgrid-v1.p.rapidapi.com");
            request.AddParameter("application/json", "{\r\n    \"personalizations\": [\r\n        {\r\n            \"to\": [\r\n                {\r\n                    \"email\": \"adil.joldic@yahoo.com\"\r\n                }\r\n            ],\r\n            \"subject\": \"Hello, World!\"\r\n        }\r\n    ],\r\n    \"from\": {\r\n        \"email\": \"adil.joldic@gmail.com\"\r\n    },\r\n    \"content\": [\r\n        {\r\n            \"type\": \"text/plain\",\r\n            \"value\": \"Hello, World from Adil\"\r\n        }\r\n    ]\r\n}", ParameterType.RequestBody);
            var response = client.Execute(request);
            */

            var googlePass = "webddmeatrskrcps";
            var googelAccount = "nastava.fit.1@gmail.com";

            String SendMailFrom = googelAccount;
            String SendMailTo = "adil@fit.ba";
            String SendMailSubject = "Email Subject";
            String SendMailBody = "Email Body";

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage email = new MailMessage();
            // START
            email.From = new MailAddress(SendMailFrom);
            email.To.Add(SendMailTo);
            email.CC.Add(SendMailFrom);
            email.Subject = SendMailSubject;
            email.Body = SendMailBody;
            //END
            SmtpServer.Timeout = 5000;
            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new NetworkCredential(SendMailFrom, googlePass);
            SmtpServer.Send(email);
        }
    }
}
