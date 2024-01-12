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
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(MessageViewModel message)
        {
            message.UserId = await RetornarIdUsuarioLogado();

            var messageMap = _Imapper.Map<Message>(message);
            await _Imessage.Add(messageMap);

            return messageMap.Notificacoes;

        }

        [Authorize]
        [Produces("application/json")]
        [HttpPut("/api/Update")]
        public async Task<List<Notifies>> Update(MessageViewModel message)
        {
            
            var messageMap = _Imapper.Map<Message>(message);
            await _Imessage.Update(messageMap);

            return messageMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Delete")]
        public async Task<List<Notifies>> Delete(MessageViewModel message)
        {
          
            var messageMap = _Imapper.Map<Message>(message);
            await _Imessage.Delete(messageMap);

            return messageMap.Notificacoes;

        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/GetEntityById")]
        public async Task<MessageViewModel> GetEntityById(Message message)
        {
            message = await _Imessage.GetEntityById(message.Id);
            var messageMap = _Imapper.Map<MessageViewModel>(message);

            return messageMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/List")]
        public async Task<List<MessageViewModel>> List()
        {
            
            var messages = await _Imessage.List();
            var messageMap = _Imapper.Map<List<MessageViewModel>>(messages);

            return messageMap;
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
