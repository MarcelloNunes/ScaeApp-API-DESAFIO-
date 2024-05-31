using AutoMapper;
using ScaeApp.API.Models;
using ScaeApp.Domain.Entities;

namespace ScaeApp.API.Mappings
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            //ClientesPostRequestModel => Cliente
            CreateMap<ClientesPostRequestModel, Cliente>();
            CreateMap<ClientesPutRequestModel, Cliente>();
            CreateMap<Cliente, ClientesGetResponseModel>();
            //Cliente => DeleteClientesResponseModel
            CreateMap<Cliente, DeleteClientesResponseModel>();
        }
    }
}
