using System.ComponentModel;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using whatsappApi.Models;
using whatsappApi.Services;

namespace whatsappApi.Business
{
    public class WhatsAppService : IWhatsAppService
    {
        private readonly WhatsAppSettings _settings;
        public WhatsAppService(IOptions<WhatsAppSettings> settings)
        {
            _settings = settings.Value;
        }

        public async  Task<bool> SendMessage(string mobile, string language, string template, List<WhatsappComponent>? components = null)
        {
            using HttpClient httpClient = new();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.Token);

            var body = new WhatsAppRequest()
            {
                to = mobile,
                template = new Template
                {
                    name = "hello_world",
                    language = new Language
                    {
                        code = language
                    }
                }
            };
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(new Uri(_settings.ApiUrl), body);
           return response.IsSuccessStatusCode;

        }
    }
}
