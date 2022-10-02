using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using whatsappApi.Dtos;
using whatsappApi.Models;
using whatsappApi.Services;

namespace whatsappApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IWhatsAppService _whatsAppService;
        public  AuthController (IWhatsAppService whatsAppService)
        {
            _whatsAppService = whatsAppService;
        }

        

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage(SendMessageDto dto)
        {
            var language = Request.Headers["language"].ToString();
            var result = await _whatsAppService.SendMessage(dto.Mobile, language, "hello_world");
            
            if (!result)
            {
                throw new Exception("Hata");
            }
            else
            {
                return Ok(result);
            }


        }
    }
}
