using DHG.Api.Models;
using DHG.Api.ViewModels;
using DHG.DataAccess.Repository.Contracts;
using DHG.DataAccess.Repository.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroDiarioController : ControllerBase
    {

        private readonly IRegistroDiarioRepository _repository;

        private RegistroDiarioList _registroDiarioList;

        public RegistroDiarioController(IRegistroDiarioRepository repository)
        {
            _repository = repository;
            this._registroDiarioList = new RegistroDiarioList();
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroDiario(int id, [FromBody] RegistroDiarioViewModel viewModel)
        {
           
            if (id != viewModel.Id)
            {              
                return BadRequest("O ID da rota deve corresponder ao ID do registro no corpo da requisição.");
            }

           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entidade = new DHG.DataAccess.Models.RegistroDiario
            {
                Id = viewModel.Id, 
                DataRegistro = viewModel.DataRegistro,
                EmocaoPrincipal = viewModel.EmocaoPrincipal,
                NivelIntensidade = viewModel.NivelIntensidade,
                DescricaoGatilho = viewModel.DescricaoGatilho,
                NotasAdicionais = viewModel.NotasAdicionais
            };

          
            var sucesso = await _repository.AtualizarAsync(entidade);

            if (sucesso)
            {                
                return NoContent();
            }
            else
            {               
                return NotFound($"Registro com ID {id} não encontrado ou erro de concorrência.");
            }
        
        }

        //***********************************************************************************
        //***********************************************************************************

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroDiario(int id)
        {            
            var sucesso = await _repository.RemoverAsync(id);

            if (sucesso)
            {              
                return NoContent();
            }
            else
            {              
                return NotFound($"Registro com ID {id} não encontrado.");
            }
        }

        //***********************************************************************************
        //***********************************************************************************

        //[HttpGet]
        //public ActionResult<List<DHG.DataAccess.Models.RegistroDiario>> GetRegistrosDiarios()
        //{
        //    var registros = _registroDiarioList.GetRegistroDiarios();
        //    return Ok( registros );
        //}

        //[HttpGet("{id}")]
        //public ActionResult<DHG.DataAccess.Models.RegistroDiario> GetRegistroDiarioById(int id)
        //{
        //    var registro = _registroDiarioList.GetRegistroDiarioById(id);
        //    return Ok(registro);
        //}

        //public ActionResult AddRegistroDiario(DHG.DataAccess.Models.RegistroDiario registroDiario)
        //{
        //    var valor = _registroDiarioList.AddRegistroDiario(registroDiario);

        //    if (valor == 1)
        //    {
        //        return Ok();
        //    }

        //    return BadRequest();

        //}

        //[HttpPut]
        //public ActionResult UpdateRegistroDiario([FromBody]DHG.DataAccess.Models.RegistroDiario registroDiario)
        //{
        //    var atualizado = _registroDiarioList.EditRegistroDiario(registroDiario);

        //    if (atualizado)
        //    {
        //       return Ok();
        //    }

        //    return BadRequest();

        //}

    }

}
