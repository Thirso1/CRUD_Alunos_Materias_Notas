using CRUD_AlunosMateriasNotas.Context;
using CRUD_AlunosMateriasNotas.Models;
using CRUD_AlunosMateriasNotas.Repository.Interfaces;

namespace CRUD_AlunosMateriasNotas.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private IConfiguration _conf;
        private AppDbContext _banco;

        public AlunoRepository(AppDbContext banco, IConfiguration conf)
        {
            _banco = banco;
            _conf = conf;
        }
        public void Atualizar(Aluno aluno)
        {
            _banco.Update(aluno);
            _banco.SaveChanges();
        }

        public void Cadastrar(Aluno aluno)
        {
            _banco.Add(aluno);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Aluno aluno = ObterAluno(Id);
            _banco.Remove(aluno);
            _banco.SaveChanges();
        }

        public Aluno ObterAluno(int Id)
        {
            return _banco.Alunos.Find(Id);
        }

        public List<Aluno> ObterTodosAlunos()
        {
            return _banco.Alunos.ToList();
        }

        public List<Aluno> ObterTodosAlunos(string pesquisa)
        {         
            return _banco.Alunos.Where(a => a.Nome.Contains(pesquisa.Trim())).ToList();

        }
    }
}
