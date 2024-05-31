using ScaeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaeApp.Domain.Interface.Services
{
    public interface IClienteDomainService
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        Cliente Deletar(Guid id);

        List<Cliente> ObterTodos();

        Cliente? ObterPorId(Guid id);
    }
}
