using DHG.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHG.DataAccess.Repository.Contracts
{
    public interface IRegistroDiarioRepository : IDisposable
    {
      
        Task<RegistroDiario> AdicionarAsync(RegistroDiario registro);
       
        Task<RegistroDiario?> ObterPorIdAsync(int id);
       
        Task<IEnumerable<RegistroDiario>> ObterTodosAsync();
              
        Task<IEnumerable<RegistroDiario>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
 
        Task<bool> AtualizarAsync(RegistroDiario registro);

        Task<bool> RemoverAsync(int id);

    }
}
