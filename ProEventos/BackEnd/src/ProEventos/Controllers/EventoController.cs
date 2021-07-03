using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : Controller
    {
        public IEnumerable<Evento> _evento = new Evento[]
        {
            new Evento()
                {
                Id = 1,
                Local = "Belo Horizonte",
                Tema = "Angular",
                QtdPessoas = 250,
                Lote = "1º",
                DataEvento = DateTime.Now.AddDays(2),
                ImagemURL = "foto.png"
            },
            new Evento()
                {
                Id = 2,
                Local = "São Paulo",
                Tema = ".NET",
                QtdPessoas = 350,
                Lote = "3º",
                DataEvento = DateTime.Now.AddDays(4),
                ImagemURL = "foto.png"
            }
        };

        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(x => x.Id == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de post";
        }

        [HttpPut("{id}")]
        public string Put()
        {
            return "Exemplo de put";
        }
    }

}
