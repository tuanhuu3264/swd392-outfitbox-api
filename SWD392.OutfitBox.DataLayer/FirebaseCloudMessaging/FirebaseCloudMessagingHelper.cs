using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.FirebaseCloudMessaging
{
    public class FirebaseCloudMessagingHelper
    {   
        // Trước khi xài, hãy đăng kí Firebase.CreateApp 

        // gửi theo topic
        public static async Task<string> SendNotificationToTopic(string topic, string title, string body)
        {
            var message = new Message()
            {
                Topic = topic,
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                }
            };
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            return response;
        }
        // gửi đến end-user (token : deviceToken) 
        public static  async Task<string> SendNotification(string token, string title, string body)
        {
            var message = new Message()
            {
                Token = token,
                Notification = new Notification()
                {
                    Title = title,
                    Body = body,
                },
                Data = new Dictionary<string, string>()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            }
            };


            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            return response;
        }
/*        // Tạo một nhóm các đối tượng (end-user, device-tokens)  có chung một đặc điểm. Cần có các device-tokens của các end-users đó  
        public async Task<string> CreateDeviceGroup(string userId, List<string> tokens)
        {
            // Notification key
            string notificationKey = "your-notification-key";

            try
            {
                // Tạo nhóm thiết bị
                string response = await FirebaseMessaging.DefaultInstance.CreateDeviceGroupAsync(userId, tokens, notificationKey);
                return response; // Trả về notification key mới
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating device group: " + ex.Message);
                return null;
            }
        }
        // gửi thông báo cho nhóm đối tượng 
        public static  async Task SendNotificationToDeviceGroup(string notificationKey, string title, string body)
        {
            var message = new Message()
            {
                Notification = new Notification()
                {
                    Title = title,
                    Body = body,
                },
                Token = notificationKey // Sử dụng notification key
            };

            try
            {
                string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                Console.WriteLine("Successfully sent message: " + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending message: " + ex.Message);
            }
        }*/
        // gửi thông báo cho những message có điều kiện
        public static  async Task<bool> SendNotificationWithCondition(string condition, string title, string body)
        {
            var message = new Message()
            {
                Condition = condition,
                Notification = new Notification()
                {
                    Title = title,
                    Body = body,
                }
            };
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            return true;
        }
    }
}
