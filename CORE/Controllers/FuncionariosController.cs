
using System;
using System.Linq;
using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using CORE.Database;


namespace CORE.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDBContext database;

        public FuncionariosController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            var funcionarios = database.Funcionarios.ToList();
            return View(funcionarios);
        }

        public IActionResult Editar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            return View("Cadastrar", funcionario);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }


        public IActionResult Deletar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            database.Funcionarios.Remove(funcionario);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario)
        {
            if (funcionario.Id == 0)
            {
                //adicionando um novo objeto do tipo funcionário
                database.Funcionarios.Add(funcionario);
            }
            else
            {
                //caso o funcionario já exista no banco de dados, será feita a atualização dos dados
                Funcionario funcionarioDoBanco = database.Funcionarios.First(registro => registro.Id == funcionario.Id);
                funcionarioDoBanco.Nome = funcionario.Nome;
                funcionarioDoBanco.Salario = funcionario.Salario;
                funcionarioDoBanco.Cpf = funcionario.Cpf;
            }
            //o método abaixo é indispensável para salvar o objeto funcionário no banco de dados! 
            database.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}