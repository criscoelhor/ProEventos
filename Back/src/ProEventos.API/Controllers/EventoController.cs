using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return new Evento[]{ 
                new Evento(){
                    EventoId = 1,
                    Tema = "Angular 11 e.NET 5",
                    Local = "Porto Alegre",
                    Lote = "1 Lote",
                    QtdPessoas = 250,
                    Dataevento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImageURL = "foto.png"
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Angular e Novidades",
                    Local = "São Paulo",
                    Lote = "2 Lote",
                    QtdPessoas = 200,
                    Dataevento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy"),
                    ImageURL = "foto2.png"
                }
            };
        }
    }
}
