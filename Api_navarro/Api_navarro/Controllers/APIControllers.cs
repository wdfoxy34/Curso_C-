using Microsoft.AspNetCore.Mvc;

namespace Api_navarro.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class APIControllers : Controller
    {
        static List<Curso> List =
        [
            new Curso(1, "eneias", "presidente","yes", 250),
            new Curso(2, "Matheus", "ADS","Null", 23),
        ];

        [HttpGet]
        public IActionResult get()
        {
            return Ok(List);
        }

        [HttpGet("{Id}")]
        public IActionResult getbyId(int id) 
        {
            var curso = List.Find(x => x.Id == id);
            if (curso == null) 
            {
                return NotFound( new { Mensage = $"Curso ao encontrado id={id}"});
            }
            return Ok(curso);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Curso newCurso)
        {
            if (newCurso == null) 
            {
                return BadRequest("o campo não existe ");
            }
            if (List.Any(x => x.Id == newCurso.Id)) 
            {
                return Conflict(new { Mensagem = $"Este curso ja existe Id={newCurso.Id}"})
            }
            List.Add(newCurso);
            return CreatedAtAction(nameof(get), new { id = newCurso.Id }, newCurso);


               
        }


    }
}
