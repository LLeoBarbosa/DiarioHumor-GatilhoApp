using System.ComponentModel.DataAnnotations;

namespace DHG.Api.Models
{
    public class RegistroDiario
    {

        public RegistroDiario()
        {
        }

        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public string? EmocaoPrincipal { get; set; }
        public int NivelIntensidade { get; set; }
        public string? DescricaoGatilho { get; set; }
        public string? NotasAdicionais { get; set; }

    }
}
