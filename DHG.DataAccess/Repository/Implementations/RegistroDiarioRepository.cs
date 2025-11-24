using DHG.DataAccess.Context;
using DHG.DataAccess.Models;
using DHG.DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHG.DataAccess.Repository.Implementations
{
    public class RegistroDiarioRepository : IRegistroDiarioRepository
    {

        private readonly ApplicationDbContext _context;

        public RegistroDiarioRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<RegistroDiario> AdicionarAsync(RegistroDiario registro)
        {
            await _context.RegistrosDiarios.AddAsync(registro);
            await _context.SaveChangesAsync();
            return registro; 
        }

        //*********************************************************************************
        //*********************************************************************************

        public async Task<bool> AtualizarAsync(RegistroDiario registro)
        {
            throw new NotImplementedException();
        }

        //*********************************************************************************
        //*********************************************************************************

        public async Task<RegistroDiario?> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //*********************************************************************************
        //*********************************************************************************

        public async Task<IEnumerable<RegistroDiario>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        //*********************************************************************************
        //*********************************************************************************

        public async Task<IEnumerable<RegistroDiario>> ObterTodosAsync()
        {           
            return await _context.RegistrosDiarios.AsNoTracking().ToListAsync();
        }

        //*********************************************************************************
        //*********************************************************************************

        public async Task<bool> RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }

        //*********************************************************************************
        //*********************************************************************************

        public void Dispose()
        {
            _context?.Dispose();
        }

        //*********************************************************************************
        //*********************************************************************************

    }

}
