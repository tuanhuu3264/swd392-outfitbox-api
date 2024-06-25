using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392.OutfitBox.BusinessLayer.Services.NotificationService;

namespace SWD392.OutfitBox.API.Controllers
{
    
    [ApiController]
    public class NotificationController : ControllerBase
    {   
        public INotificationService NotificationService { get; set; }
        public NotificationController() 
        { 
        NotificationService ??=new NotificationService();
        }
        [HttpPost("test")]
        public async Task<string> Send(string topic, string title, string body)
        {
            var result = await NotificationService.SendMessage(topic, title, body);
            return result;
        }
        [HttpPost("test2")]
        public async Task<string> Send2(string token, string title, string body)
        {
            var result = await NotificationService.SendMessageToken(token, title, body);
            return result;
        }
    }
}
