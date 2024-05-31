namespace ScaeApp.API.Models
{
    public class ClientesGetResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public DateTime? CadastradoEm { get; set; }
        public DateTime? UltimaAtualizacaoEm { get; set; }
    }
}
