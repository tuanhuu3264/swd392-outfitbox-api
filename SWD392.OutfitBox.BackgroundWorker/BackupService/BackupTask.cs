using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SWD392.OutfitBox.BackgroundWorker.BackupService
{
    public class BackupTask : IHostedService, IDisposable
    {
        private readonly ILogger<BackupTask> _logger;
        private Timer _timer;

        public BackupTask(ILogger<BackupTask> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Database Backup Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            string connectionString = "data source=34.123.203.83;initial catalog=Outfit4Rent;user id=sa;password=<YourStrong@Passw0rd>;trustservercertificate=true;multipleactiveresultsets=true;";

            try
            {
                BackupDatabase(connectionString);
                SendEmailWithAttachment("/var/opt/mssql/backup/database_backup.bak");
                _logger.LogInformation("Database backup and email sending completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while backing up the database and sending the email.");
            }
        }

        private void BackupDatabase(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string backupQuery = $@"
                BACKUP DATABASE [Outfit4Rent] 
                TO DISK = '/var/opt/mssql/backup/database_backup.bak' 
                WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of Outfit4Rent';";

                using (SqlCommand command = new SqlCommand(backupQuery, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void SendEmailWithAttachment(string filePath)
        {
            var fromAddress = "tuanthse170219@fpt.edu.vn";
            var toAddress = "tuanthse170219@fpt.edu.vn";
            string fromPassword = "bqqi rnye ugks qshj";
            string subject = "Database Backup";
            string body = "Please find the attached database backup file.";

            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, fromPassword)
            })
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                message.Attachments.Add(new Attachment(filePath));
                smtp.Send(message);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Database Backup Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
