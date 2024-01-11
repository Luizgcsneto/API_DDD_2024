using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _Imapper;
        private readonly IMessage _Imessage;
        public MessagesController(IMapper Imapper, IMessage Imessage)
        {
            _Imapper = Imapper;
            _Imessage = Imessage;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/CriarTokenIdentity")]
        public async Task<List<Notifies>> Add(MessageViewModel message)
        {

        }


        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;
        }
    }
}
