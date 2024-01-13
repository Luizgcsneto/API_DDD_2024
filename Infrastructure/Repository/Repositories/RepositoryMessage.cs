using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryMessage : RepositoryGeneric<Message>, IMessage
    {
        private readonly DbContextOptions<ContextBase> _options;
        public RepositoryMessage()
        {
            _options = new DbContextOptions<ContextBase>(); 
        }

        public async Task<List<Message>> ListarMessages(Expression<Func<Message, bool>> exMessage)
        {
            using(var banco = new ContextBase(_options))
            {
                return await banco.Message.Where(exMessage).AsNoTracking().ToListAsync();   
            }
        }
    }
}
