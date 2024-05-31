namespace ScaeApp.API.Models
{
    public class DeleteClientesResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataHoraExclusao { get; set; }
    }
}
