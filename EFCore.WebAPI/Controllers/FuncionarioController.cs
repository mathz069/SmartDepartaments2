using EFCore.WebAPI.Data;
using EFCore.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace EFCore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly DataContext _contexto;

        public FuncionarioController(DataContext dataContext)
        {
            _contexto = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> PegarTodosFuncionarioAsync()
        {
            return await _contexto.Funcionarios.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Funcionario>> PegarIdFuncionarioAsync(int Id)
        {
            Funcionario funcionario = await _contexto.Funcionarios.FindAsync(Id);
            if (funcionario == null)
                return NotFound();

            return funcionario;

        }

        [HttpGet("por-departamento/{DepartamentoId}")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> ListarFuncionarioPorDepartamento(int DepartamentoId)
        {
            var funcionarios = await _contexto.Funcionarios
                .Where(f => f.DepartamentoId == DepartamentoId)
                .ToListAsync();

            if (funcionarios == null || funcionarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(funcionarios);
        }
        [HttpPost]
        public async Task<ActionResult<Funcionario>> SalvarFuncionarioAsync(Funcionario funcionario)
        {
            await _contexto.Funcionarios.AddAsync(funcionario);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarFuncionarioAsync(Funcionario funcionario)
        {
            _contexto.Funcionarios.Update(funcionario);
            await _contexto.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirFuncionarioAsync(int Id)
        {
            Funcionario funcionario = await _contexto.Funcionarios.FindAsync(Id);
            _contexto.Remove(funcionario);
            await _contexto.SaveChangesAsync();

            return Ok();
        }
    }
}
    

