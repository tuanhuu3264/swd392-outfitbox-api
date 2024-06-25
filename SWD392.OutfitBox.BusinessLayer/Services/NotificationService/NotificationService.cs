using SWD392.OutfitBox.DataLayer.FirebaseCloudMessaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        public async Task<string> SendMessage(string topic, string title, string body)
        {
            var result = await FirebaseCloudMessagingHelper.SendNotificationToTopic(topic, title, body);    
            return result;
        }

        public async Task<string> SendMessageToken(string token, string title, string body)
        {
            var result = await FirebaseCloudMessagingHelper.SendNotification(token, title, body);
            return result;
        }
    }
}
