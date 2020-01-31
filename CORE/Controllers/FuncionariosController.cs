
using System;
using CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CORE.Controllers
{
    public class FuncionariosController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]

         public IActionResult Salvar(Funcionario funcionario)
        {
            return Content(funcionario.Nome +" "+ funcionario.Salario +" "+ funcionario.Cpf);
        }
    }
}