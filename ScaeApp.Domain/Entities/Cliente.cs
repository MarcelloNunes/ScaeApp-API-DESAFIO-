using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaeApp.Domain.Entities
{
    public class Cliente
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public DateTime? CadastradoEm { get; set; }
        public DateTime? UltimaAtualizacaoEm { get; set; }
        //public DateTime? ExcluidoEm { get; set; }
    }
}
