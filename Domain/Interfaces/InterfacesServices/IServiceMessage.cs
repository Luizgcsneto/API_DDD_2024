using Entities.Entities;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceMessage
    {
        Task Adicionar(Message objeto);
        Task Atualizar(Message objeto);
        Task<List<Message>> ListarMensagensAtivas();
    }
}
