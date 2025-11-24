using DHG.Api.Models;
using DHG.Api.ViewModels;
using DHG.DataAccess.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroDiarioController : ControllerBase
    {

        private readonly IRegistroDiarioRepository _repository;

        public RegistroDiarioController(IRegistroDiarioRepository repository)
        {
            _repository = repository;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroDiario>>> GetRegistrosDiarios()
        {
            var registros = await _repository.ObterTodosAsync();           
            return Ok(registros);
        }

        //***********************************************************************************
        //***********************************************************************************

        [HttpPost]
        public async Task<ActionResult<RegistroDiarioViewModel>> PostRegistroDiario([FromBody] RegistroDiarioViewModel viewModel)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }          
     
            var registroDiario = new DHG.DataAccess.Models.RegistroDiario()
            {
                DataRegistro = viewModel.DataRegistro,
                EmocaoPrincipal = viewModel.EmocaoPrincipal,
                NivelIntensidade = viewModel.NivelIntensidade,
                DescricaoGatilho = viewModel.DescricaoGatilho,
                NotasAdicionais = viewModel.NotasAdicionais
                
            };
           
            var entidadeSalva = await _repository.AdicionarAsync(registroDiario);
         
            viewModel.Id = entidadeSalva.Id;

            return CreatedAtAction(
                nameof(GetRegistrosDiarios), 
                new { id = viewModel.Id },   
                viewModel                    
            );

        }

        //***********************************************************************************
        //***********************************************************************************

    }

}
