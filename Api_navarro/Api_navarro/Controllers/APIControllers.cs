using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_navarro.Data;

namespace Api_navarro.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class APIControllers : Controller
    {
        private readonly Datacontext _datacontext;

        public APIControllers(Datacontext datacontext) 
        {
            _datacontext = datacontext;
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_datacontext.Cursos.ToList());
        }

        [HttpGet("{Id}")]
        public IActionResult getbyId(int id) 
        {
            var curso = _datacontext.Cursos.ToList().Find(x => x.Id == id);
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
            if (_datacontext.Cursos.Any(x => x.Id == newCurso.Id)) 
            {
                return Conflict(new { Mensagem = $"Este curso ja existe Id={newCurso.Id}" });
            }
            _datacontext.Cursos.Add(newCurso);
            _datacontext.SaveChanges();
            return CreatedAtAction(nameof(get), new { id = newCurso.Id }, newCurso);
               
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id, [FromBody] Curso updateCurso) 
        {
            if (updateCurso == null)
                return BadRequest("Campo selecionado inavalido");

            var exiting = _datacontext.Cursos.FirstOrDefault(x => x.Id == id);
            if (exiting == null)
                return NotFound(new { Mensage = $"O curso desejado nao existe em {id}" });

            _datacontext.Entry(exiting).CurrentValues.SetValues(updateCurso);
            _datacontext.SaveChanges();

            return Ok(new
            {
                Mensage = "Curso consluido com sucesso!!",
                Update = updateCurso
            });
        }

        [HttpPatch("{Id}/Complete")]
        public IActionResult PatchMarkAsComplete(int id) 
        {
            var Curso = _datacontext.Cursos.FirstOrDefault(x => x.Id == id);
            if (Curso == null)
                return NotFound(new { Mansage = $"O curso nao foi encontrado={id}" });

            Curso.IsComplete = true;
            _datacontext.Entry(Curso).CurrentValues.SetValues(Curso);
            _datacontext.SaveChanges();

            return ok(new
            {
                Mensage = $"curso completo com sucesso '{Curso.Name}'",
                Update = Curso
            });
        }

        private IActionResult ok(object value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletr(int id)
        {
            var Curso = _datacontext.Cursos.FirstOrDefault(x => x.Id == id);
            if (Curso == null)
                return NotFound(new { mensage = $"Curso nao encontrado {id}" });

            _datacontext.Cursos.Remove(Curso);
            _datacontext.SaveChanges();
            return ok(new { Mensage = $"Curso removido com sucesso '{Curso.Name}'" });
        }
    }
}
