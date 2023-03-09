using CRUD_AlunosMateriasNotas.Models;

namespace CRUD_AlunosMateriasNotas.Repository.Interfaces
{
    public interface INotaRepository
    {
        void Cadastrar(Nota nota);
        void Atualizar(Nota nota);
        void Excluir(int Id);
        Nota ObterNota(int Id);
        List<Nota> ObterTodasNotas(int AlunoId);
    }
}
