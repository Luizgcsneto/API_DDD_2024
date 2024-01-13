using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _IMessage;
        public ServiceMessage(IMessage IMessage)
        {
            _IMessage = IMessage;
        }

        public async Task Adicionar(Message objeto)
        {
            throw new NotImplementedException();
        }

        public async Task Atualizar(Message objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Message>> ListarMensagensAtivas()
        {
            throw new NotImplementedException();
        }
    }
}
