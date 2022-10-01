using Chapter1FS3.Contexts;
using Chapter1FS3.Models;

namespace Chapter1FS3.Repositories
{
    public class LivroRepository
    {

        private readonly SqlContext _context;

        public LivroRepository(SqlContext context)
        {
            _context = context;
        }

        public  List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }
    }
}
