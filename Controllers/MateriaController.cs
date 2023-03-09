using CRUD_AlunosMateriasNotas.Lib.Msg;
using CRUD_AlunosMateriasNotas.Models;
using CRUD_AlunosMateriasNotas.Repository;
using CRUD_AlunosMateriasNotas.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_AlunosMateriasNotas.Controllers
{

    public class MateriaController : Controller
    {
        private IMateriaRepository _materiaRepository;
        public MateriaController(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        [HttpGet]
        public IActionResult Index(/*int? pagina, string pesquisa*/)
        {
            List<Materia> materias = _materiaRepository.ObterTodasMaterias();
            return View(materias);
        }

        [HttpPost]
        public IActionResult Index(string pesquisa)
        {
            List<Materia> materias = _materiaRepository.ObterTodasMaterias(pesquisa);
            return View(materias);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Models.Materia materia)
        {
            if (ModelState.IsValid)
            {
                _materiaRepository.Cadastrar(materia);
                TempData["MSG_S"] = "Cadastro realizado com sucesso!";

            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Atualizar(int Id)
        {
            Materia materia = _materiaRepository.ObterMateria(Id);

            return View(materia);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Models.Materia materia)
        {
            if (ModelState.IsValid)
            {
                _materiaRepository.Atualizar(materia);

                TempData["MSG_S"] = "Cadastro realizado com sucesso!";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            _materiaRepository.Excluir(id);

            TempData["MSG_S"] = Mensagem.MSG_S002;

            return RedirectToAction(nameof(Index));
        }
    }
}
