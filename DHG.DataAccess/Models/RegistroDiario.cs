using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHG.DataAccess.Models
{
    public class RegistroDiario
    {
        public RegistroDiario()
        {
        }

        [Key]
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public string? EmocaoPrincipal { get; set; }
        public int NivelIntensidade { get; set; }
        public string? DescricaoGatilho { get; set; }
        public string? NotasAdicionais { get; set; }

    }
}
