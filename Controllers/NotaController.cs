using CRUD_AlunosMateriasNotas.Lib.Msg;
using CRUD_AlunosMateriasNotas.Models;
using CRUD_AlunosMateriasNotas.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD_AlunosMateriasNotas.Controllers
{
    public class NotaController : Controller
    {
        private INotaRepository _notaRepository;
        private IAlunoRepository _alunoRepository;
        private IMateriaRepository _materiaRepository;
        public NotaController(INotaRepository notaRepository, IAlunoRepository alunoRepository, IMateriaRepository materiaRepository)
        {
            _notaRepository = notaRepository;
            _alunoRepository = alunoRepository;
            _materiaRepository = materiaRepository;
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
        public IActionResult NotasPorAluno([FromQuery] int alunoId)
        {
            Aluno aluno = _alunoRepository.ObterAluno(alunoId);
            List<Nota> notas = _notaRepository.ObterTodasNotas(alunoId);
            ViewBag.Aluno = aluno;
            return View(notas);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            List<SelectListItem> alunos = new List<SelectListItem>();
            alunos = _alunoRepository.ObterTodosAlunos().Select(a => new SelectListItem(a.Nome, a.Id.ToString())).ToList();
            ViewBag.Alunos = alunos;

            List<SelectListItem> materias = new List<SelectListItem>();
            materias = _materiaRepository.ObterTodasMaterias().Select(a => new SelectListItem(a.Nome, a.Id.ToString())).ToList();
            ViewBag.Materias = materias;

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Models.Nota nota)
        {
            nota.Valor /= 100;

            if (ModelState.IsValid)
            {
                _notaRepository.Cadastrar(nota);
                TempData["MSG_S"] = "Cadastro realizado com sucesso!";
            }
            else
            {
                TempData["MSG_S"] = "Verifique os Campos!";
                return RedirectToAction(nameof(Cadastrar));
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Atualizar(int Id)
        {
            Nota nota = _notaRepository.ObterNota(Id);

            List<SelectListItem> alunos = new List<SelectListItem>();
            alunos = _alunoRepository.ObterTodosAlunos().Select(a => new SelectListItem(a.Nome, a.Id.ToString())).ToList();
            ViewBag.Alunos = alunos;

            List<SelectListItem> materias = new List<SelectListItem>();
            materias = _materiaRepository.ObterTodasMaterias().Select(a => new SelectListItem(a.Nome, a.Id.ToString())).ToList();
            ViewBag.Materias = materias;

            return View(nota);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Models.Nota nota)
        {
            if (ModelState.IsValid)
            {
                _notaRepository.Atualizar(nota);

                TempData["MSG_S"] = "Cadastro realizado com sucesso!";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            _notaRepository.Excluir(id);

            TempData["MSG_S"] = Mensagem.MSG_S002;

            return RedirectToAction(nameof(Index));
        }
    }
}
