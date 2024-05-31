using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScaeApp.API.Models;
using ScaeApp.Domain.Entities;
using ScaeApp.Domain.Exceptions;
using ScaeApp.Domain.Interface.Services;
using ScaeApp.Infra.Data.Repositories;

namespace ScaeApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteDomainService _clienteDomainService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteDomainService clienteDomainService, IMapper mapper)
        {
            _clienteDomainService = clienteDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClientesGetResponseModel), 201)]
        public IActionResult Post(ClientesPostRequestModel model)
        {
            try
            {
                var cliente = _clienteDomainService.Adicionar(_mapper.Map<Cliente>(model));

                var response = _mapper.Map<ClientesGetResponseModel>(cliente);

                return StatusCode(201, response);
            }
            catch (DomainException e)
            {
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ClientesGetResponseModel), 200)]
        public IActionResult Put(ClientesPutRequestModel model)
        {
            try
            {
                var cliente = _clienteDomainService.Atualizar(_mapper.Map<Cliente>(model));

                var response = _mapper.Map<ClientesGetResponseModel>(cliente);

                return StatusCode(200, response);
            }
            catch (DomainException e)
            {
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteClientesResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var cliente = _clienteDomainService.Deletar(id);

                var response = _mapper.Map<DeleteClientesResponseModel>(cliente);
                response.DataHoraExclusao = DateTime.Now;

                return StatusCode(200, response);
            }
            catch (DomainException e)
            {
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ClientesGetResponseModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var clientes = _clienteDomainService.ObterTodos();

                if (!clientes.Any())
                    return StatusCode(204);

                var response = _mapper.Map<List<ClientesGetResponseModel>>(clientes);

                return StatusCode(200, response);
            }

            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
