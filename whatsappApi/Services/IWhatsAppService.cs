using System.ComponentModel;
using whatsappApi.Models;

namespace whatsappApi.Services
{
    public interface IWhatsAppService
    {
        Task<bool> SendMessage(string mobile, string language, string template, List<WhatsappComponent>? components=null);
    }
}
