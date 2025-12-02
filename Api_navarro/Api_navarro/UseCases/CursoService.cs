using Api_navarro.Domain.Entities;
using Api_navarro.Domain.Interfaces;


namespace Api_navarro.UseCases
{
    public class CursoUsecase
    {
        private readonly ICursoRepository _repo;
        
        public CursoUsecase(ICursoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Curso?>> BuscarAsync(string tipo, string valor, string filtro)
        {
            switch (tipo.ToLower()) 
            {
                case "nome":
                    List<Curso?> cursos = await _repo.GetByNameAsync(valor);
                    return cursos;

                case "id":
                    Curso curso = await _repo.GetByIdAsync(Convert.ToInt32(valor));
                    return curso is null ? new List<Curso?>() : new List<Curso?> { curso };

                case "tipo":
                    return await _repo.GetByTypeAsync(valor);

                case "status":
                    return await _repo.GetByCompletionAsync(Convert.ToBoolean(valor));

                case "preco":
                    return await _repo.GetByPriceAsync(Convert.ToDecimal(valor), filtro);
                
                default:
                    string erroString = ($"Parametro de pesquisa '{valor}' invalido");
                    throw new Exception(erroString); 
            }
        }

        public async Task<Curso?> AddAsync(
            string name,
            string description,
            string type,
            decimal preco
            )
        {
            if (name == null) throw new ArgumentNullException("Argumento faltante: name");
            if (description == null) throw new ArgumentNullException("Argumento faltante: description");
            if (type == null) throw new ArgumentNullException("Argumento faltante: type");
            if (preco <= 0) throw new ArgumentException("Pre�o dever ser maior que 0");

            Curso curso = new Curso(name, description, type, preco);
            await _repo.AddAsync(curso);
            return curso;
        }
    }
}