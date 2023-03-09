using CRUD_AlunosMateriasNotas.Context;
using CRUD_AlunosMateriasNotas.Models;
using CRUD_AlunosMateriasNotas.Repository.Interfaces;

namespace CRUD_AlunosMateriasNotas.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        private IConfiguration _conf;
        private AppDbContext _banco;

        public MateriaRepository(AppDbContext banco, IConfiguration conf)
        {
            _banco = banco;
            _conf = conf;
        }

        public void Atualizar(Materia materia)
        {
            _banco.Update(materia);
            _banco.SaveChanges();
        }

        public void Cadastrar(Materia materia)
        {
            _banco.Add(materia);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Materia materia = ObterMateria(Id);
            _banco.Remove(materia);
            _banco.SaveChanges();
        }

        public Materia ObterMateria(int Id)
        {
            return _banco.Materias.Find(Id);
        }

        public List<Materia> ObterTodasMaterias()
        {
            return _banco.Materias.ToList();
        }
        public List<Materia> ObterTodasMaterias(string pesquisa)
        {
            return _banco.Materias.Where(a => a.Nome.Contains(pesquisa.Trim())).ToList();
        }
    }
}
