using System.ComponentModel.DataAnnotations;

namespace ScaeApp.API.Models
{
    /// <summary>
    /// Modelo de dados para a requisição de cadastro de cliente
    /// </summary>
    public class ClientesPostRequestModel
    {
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string? Nome { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido.")] //771.786.172-09
        [Required(ErrorMessage = "Por favor, informe o cpf do cliente.")]
        public string? Cpf { get; set; }

        [RegularExpression(@"^\(\d{2}\) \d{4}-\d{4}$", ErrorMessage = "Número de telefone inválido. Formato esperado: (XX) XXXX-XXXX.")]
        [Required(ErrorMessage = "Por favor, informe o telefone do cliente.")]
        public string? Telefone { get; set; }
    }
}
