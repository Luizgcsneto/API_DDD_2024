using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class Notifies
    {
        public Notifies()
        {
            Notificacoes = new List<Notifies>();
        }
        [NotMapped]
        public string NomePropriedade { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }
        [NotMapped]
        public List<Notifies> Notificacoes { get; set; }
    }
}
