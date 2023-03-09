using CRUD_AlunosMateriasNotas.Models;
using CRUD_AlunosMateriasNotas.Lib.Msg;
using Microsoft.AspNetCore.Mvc;
using CRUD_AlunosMateriasNotas.Repository.Interfaces;
using CRUD_AlunosMateriasNotas.Repository;

namespace CRUD_AlunosMateriasNotas.Controllers
{
  
    public class AlunoController : Controller
    {
        private IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Aluno> alunos = _alunoRepository.ObterTodosAlunos();
            return View(alunos);
        }

        [HttpPost]
        public IActionResult Index(string pesquisa)
        {
            List<Aluno> alunos = _alunoRepository.ObterTodosAlunos(pesquisa);
            return View(alunos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Models.Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _alunoRepository.Cadastrar(aluno);
                TempData["MSG_S"] = "Cadastro realizado com sucesso!";
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Atualizar(int Id)
        {
            Models.Aluno aluno = _alunoRepository.ObterAluno(Id);
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Models.Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _alunoRepository.Atualizar(aluno);
                TempData["MSG_S"] = "Aluno atualizado com sucesso!";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            _alunoRepository.Excluir(id);
            TempData["MSG_S"] = Mensagem.MSG_S002;
            return RedirectToAction(nameof(Index));
        }
    }
}
