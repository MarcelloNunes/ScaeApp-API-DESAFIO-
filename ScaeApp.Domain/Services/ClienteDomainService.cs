using ScaeApp.Domain.Entities;
using ScaeApp.Domain.Exceptions;
using ScaeApp.Domain.Interface.Repositories;
using ScaeApp.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaeApp.Domain.Services
{
    public class ClienteDomainService : IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            cliente.CadastradoEm = DateTime.Now;
            cliente.UltimaAtualizacaoEm = DateTime.Now;

            _clienteRepository.Add(cliente);

            return cliente;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            #region Buscar o cliente no bd através do ID

            var clienteEdicao = _clienteRepository.GetById(cliente.Id.Value);
            DomainException.When(clienteEdicao == null, "O cliente é inválido para edição. Por favor, verifique o Id do cliente.");

            #endregion

            #region Alterar dados do cliente

            clienteEdicao.Nome = cliente.Nome;
            clienteEdicao.Cpf = cliente.Cpf;
            clienteEdicao.Telefone = cliente.Telefone;
            clienteEdicao.UltimaAtualizacaoEm = DateTime.Now;

            _clienteRepository.Update(clienteEdicao);

            return clienteEdicao;

            #endregion
        }

        public Cliente Deletar(Guid id)
        {
            var clienteExclusao = _clienteRepository.GetById(id);
            DomainException.When(clienteExclusao == null, "O cliente é inválido para exclusão. Por favor, verifique o ID do cliente.");

            _clienteRepository.Delete(clienteExclusao);

            return clienteExclusao;
        }

        public List<Cliente> ObterTodos()
        {
            return _clienteRepository.GetAll();
        }       

        public Cliente? ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
