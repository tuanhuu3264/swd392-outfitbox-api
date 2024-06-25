using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.NotificationService
{
    public interface INotificationService
    {
        public Task<string> SendMessage(string topic, string title, string body);
        public Task<string> SendMessageToken(string token, string title, string body);
    }
}
