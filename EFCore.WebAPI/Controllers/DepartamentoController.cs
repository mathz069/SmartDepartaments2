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
    public class DepartamentoController : ControllerBase
    {
        private readonly DataContext _contexto;

        public DepartamentoController(DataContext dataContext)
        {
            _contexto = dataContext;
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> SalvarDepartamentoAsync(Departamento departamento)
        {
            if (departamento == null)
            {
                return BadRequest("O departamento não pode ser nulo.");
            }
               

            await _contexto.Departamentos.AddAsync(departamento);
                await _contexto.SaveChangesAsync();

                return Ok();
            }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> PegarTodosDepartamentoAsync()
        {
            return await _contexto.Departamentos.ToListAsync();
        }

            [HttpGet("{Id}")]
        public async Task<ActionResult<Departamento>> PegarIdDepartamentoAsync(int Id) {
            Departamento departamento = await _contexto.Departamentos.FindAsync(Id);
            if (departamento == null)
                return NotFound();

            return departamento;
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarDepartamentoAsync(Departamento departamento)
        {
            _contexto.Departamentos.Update(departamento);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

            [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirDepartamentoAsync (int Id) 
        {
            Departamento departamento = await _contexto.Departamentos.FindAsync(Id);
            _contexto.Remove(departamento);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

    }
}
