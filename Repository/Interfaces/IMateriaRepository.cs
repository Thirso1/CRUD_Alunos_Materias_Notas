using CRUD_AlunosMateriasNotas.Models;

namespace CRUD_AlunosMateriasNotas.Repository.Interfaces
{
    public interface IMateriaRepository
    {
        void Cadastrar(Materia materia);
        void Atualizar(Materia materia);
        void Excluir(int Id);
        Materia ObterMateria(int Id);
        List<Materia> ObterTodasMaterias();
        List<Materia> ObterTodasMaterias(string pesquisa);
    }
}
