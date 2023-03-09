using CRUD_AlunosMateriasNotas.Models;
using X.PagedList;

namespace CRUD_AlunosMateriasNotas.Repository.Interfaces
{
    public interface IAlunoRepository
    {
        void Cadastrar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Excluir(int Id);
        Aluno ObterAluno(int Id);
        List<Aluno> ObterTodosAlunos();
        List<Aluno> ObterTodosAlunos(string pesquisa);

    }
}
