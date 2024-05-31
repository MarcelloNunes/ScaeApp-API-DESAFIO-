using ScaeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaeApp.Domain.Interface.Repositories
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);

        List<Cliente> GetAll();

        Cliente? GetById(Guid id);
    }
}
