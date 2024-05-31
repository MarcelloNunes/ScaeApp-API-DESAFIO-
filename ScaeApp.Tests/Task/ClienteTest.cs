using Bogus;
using FluentAssertions;
using ScaeApp.API.Models;
using ScaeApp.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScaeApp.Tests.Task
{
    public class ClienteTest
    {
        private Faker _faker => new Faker("pt_BR");
        private string _endpoint => "/api/clientes";

        public class ClientesTests
        {
            private readonly Faker _faker;
            private readonly string _endpoint;

            public ClientesTests()
            {
                _faker = new Faker("pt_BR");
                _endpoint = "/api/clientes"; // Substitua pelo endpoint correto
            }

            [Fact]
            public void Post_Clientes_Returns_Created()
            {
                var request = new ClientesPostRequestModel
                {
                    Nome = _faker.Lorem.Sentence(1), // Corrigido para gerar uma frase única
                    Cpf = _faker.Random.Replace("###.###.###-##"),
                    Telefone = _faker.Phone.PhoneNumber("(##) ####-####")
                };

                var result = TestHelper.CreateClient.PostAsync(_endpoint, TestHelper.CreateContent(request)).Result;

                result.StatusCode.Should().Be(HttpStatusCode.Created);

                // Lendo os dados obtidos da API
                var response = TestHelper.ReadContent<ClientesGetResponseModel>(result);

                response?.Id.Should().NotBeEmpty(); // ID não pode ser vazio
                response?.Nome.Should().Be(request.Nome); // Nome deve ser igual ao valor enviado
                response?.Cpf.Should().Be(request.Cpf); // CPF deve ser igual ao valor enviado
                response?.Telefone.Should().Be(request.Telefone); // Telefone deve ser igual ao valor enviado
                response?.CadastradoEm.Should().NotBeNull(); // CadastradoEm não pode ser nulo
                response?.UltimaAtualizacaoEm.Should().NotBeNull(); // UltimaAtualizacaoEm não pode ser nulo
            }
        }

        [Fact(Skip = "Não implementado.")]
        public void Put_Clientes_Returns_Ok()
        {
            //TODO
        }

        [Fact(Skip = "Não implementado.")]
        public void Delete_Clientes_Returns_Ok()
        {
            //TODO
        }

        [Fact(Skip = "Não implementado.")]
        public void GetAll_Clientes_Returns_Ok()
        {
            //TODO
        }
    }
}
