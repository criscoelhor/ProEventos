using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain;
using ProEventos.Application.Contratos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if(eventos == null) return NotFound("Nenhum evento encontrado.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError,              
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id);
                if(evento == null) return NotFound("Nenhum evento encontrado para o Id.");

                return Ok(evento);
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,              
                    $"Erro ao tentar recuperar o evento. Erro: {ex.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosByTemaAsync(tema);
                if(eventos == null) return NotFound("Nenhum evento encontrado para o tema.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,              
                    $"Erro ao tentar recuperar o evento. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);
                if(evento == null) return BadRequest("Erro ao tentar adicionar o evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,              
                    $"Erro ao tentar recuperar o evento. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);
                if(evento == null) return BadRequest("Erro ao tentar atualizar o evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,              
                    $"Erro ao tentar atualizar o evento. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(await _eventoService.DeleteEvento(id))
                    return Ok("Deletado");

                else
                    return BadRequest("Erro ao tentar deletar o evento.");
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,              
                    $"Erro ao tentar recuperar o evento. Erro: {ex.Message}");
            }
        }
    }
}
