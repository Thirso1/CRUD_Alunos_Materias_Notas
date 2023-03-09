using CRUD_AlunosMateriasNotas.Context;
using CRUD_AlunosMateriasNotas.Models;
using CRUD_AlunosMateriasNotas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUD_AlunosMateriasNotas.Repository
{
    public class NotaRepository : INotaRepository
    {
        private IConfiguration _conf;
        private AppDbContext _banco;
        public NotaRepository(AppDbContext banco, IConfiguration conf)
        {
            _banco = banco;
            _conf = conf;
        }
        public void Atualizar(Nota nota)
        {
            _banco.Update(nota);
            _banco.SaveChanges();
        }

        public void Cadastrar(Nota nota)
        {
            _banco.Add(nota);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Nota nota = ObterNota(Id);
            _banco.Remove(nota);
            _banco.SaveChanges();
        }
        public Nota ObterNota(int Id)
        {
            Nota nota = _banco.Notas.Find(Id);
            return nota;
        }

        public List<Nota> ObterTodasNotas(int alunoId)
        {
            List<Nota> list = _banco.Notas.Where(n => n.AlunoId == alunoId).Include(a => a.Aluno).Include(M => M.Materia).ToList();
            return list;
        }
    }
}
