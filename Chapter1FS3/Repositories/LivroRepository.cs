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

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastrar(Livro l)
        {
            _context.Livros.Add(l);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro l = _context.Livros.Find(id);

            _context.Livros.Remove(l);

            _context.SaveChanges();
        }

        public void Alterar(int id, Livro l)
        {
            Livro LivroBuscado = _context.Livros.Find(id);
            if (LivroBuscado != null)
            {
                LivroBuscado.Titulo = l.Titulo;
                LivroBuscado.QauntidadePaginas = l.QauntidadePaginas;
                LivroBuscado.Disponivel = l.Disponivel;

                _context.Livros.Update(LivroBuscado);
                _context.SaveChanges();
            }
        }
    }
}
