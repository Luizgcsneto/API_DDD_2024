using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryMessage : RepositoryGeneric<Message>, IMessage
    {
        private readonly DbContextOptions<ContextBase> _options;
        public RepositoryMessage()
        {
            _options = new DbContextOptions<ContextBase>(); 
        }


    }
}
