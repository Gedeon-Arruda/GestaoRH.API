using GestaoRH.Aplicacao.Interfaces;
using GestaoRH.Aplicacao.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestaoRH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioServico _funcionarioServico;

        public FuncionarioController(IFuncionarioServico funcionarioServico)
        {
            _funcionarioServico = funcionarioServico;
        }

        [HttpPost]
        public IActionResult Criar(FuncionarioViewModel funcionarioVw)
        {
            var retorno = _funcionarioServico.Criar(funcionarioVw);

            return Ok(retorno);
        }

        [HttpPut]
        public IActionResult Editar(FuncionarioViewModel funcionarioVw)
        {
            var retorno = _funcionarioServico.Editar(funcionarioVw);

            if (retorno == null)
            {
                return BadRequest();
            }

            return Ok(retorno);
        }

        [HttpGet]
        public IActionResult Obter()
        {
            var retorno = _funcionarioServico.Obter();
            
            return Ok(retorno);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(Guid id)
        {
            if (Guid.Empty == id)
            {
                return NotFound();
            }

            _funcionarioServico.Excluir(id);

            return Ok();
        }
    }
}