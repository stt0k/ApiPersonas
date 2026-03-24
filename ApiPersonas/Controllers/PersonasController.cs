using ApiPersonas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private List<Persona> personas;

        public PersonasController()
        {
            personas = new List<Persona>
            {
                new Persona
                {
                    IdPersona = 1,
                    Nombre = "Paco",
                    Email = "paco@gmail.com",
                    Edad = 47
                },
                new Persona
                {
                    IdPersona = 2,
                    Nombre = "Antonia",
                    Email = "antonia@gmail.com",
                    Edad = 42
                },
                new Persona
                {
                    IdPersona = 3,
                    Nombre = "Roberto",
                    Email = "roberto@gmail.com",
                    Edad = 30
                },
                new Persona
                {
                    IdPersona = 4,
                    Nombre = "Pepe",
                    Email = "pepe@gmail.com",
                    Edad = 82
                }
            };
        }

        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            return personas;
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> Find(int id)
        {
            return personas.FirstOrDefault(e => e.IdPersona == id);
        }
    }
}
