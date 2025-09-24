using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManager.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _path = "Emails.txt";

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = $"To: {to}\nSubject: {subject}\nBody: {body}\n---\n";
            await File.AppendAllTextAsync(_path, message);

            Console.WriteLine("E-mail enviado para " + to);
            Console.WriteLine(message);
        }
    }
}
