using System.ComponentModel.DataAnnotations;

namespace DHG.Client.ViewModel
{
    public class RegistroDiarioViewModel
    {       
        public int Id { get; set; }

        [Required(ErrorMessage = "A data do registro é obrigatória.")]
        [Display(Name = "Data e Hora")]
        public DateTime DataRegistro { get; set; }

        [Required(ErrorMessage = "A emoção principal é obrigatória.")]
        [StringLength(50)]
        [Display(Name = "Emoção Principal")]
        public string EmocaoPrincipal { get; set; } = string.Empty;

        [Range(1, 10, ErrorMessage = "A intensidade deve ser de 1 a 10.")]
        [Display(Name = "Nível de Intensidade")]
        public int NivelIntensidade { get; set; }

        [Required(ErrorMessage = "A descrição do gatilho é obrigatória.")]
        [Display(Name = "Gatilho/Causa")]
        public string DescricaoGatilho { get; set; } = string.Empty;

        [Display(Name = "Notas Adicionais")]
        public string? NotasAdicionais { get; set; }

    }

}
