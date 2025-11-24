using System.ComponentModel.DataAnnotations;

namespace DHG.Api.ViewModels
{
    public class RegistroDiarioViewModel
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public string? EmocaoPrincipal { get; set; } = string.Empty;
        public int NivelIntensidade { get; set; }
        public string? DescricaoGatilho { get; set; } = string.Empty;
        public string? NotasAdicionais { get; set; }

    }
}
