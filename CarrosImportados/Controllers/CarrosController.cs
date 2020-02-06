using CarrosImportados.Models;
using Microsoft.AspNetCore.Mvc;
using CarrosImportados.Database;

namespace CarrosImportados.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ApplicationDBContext database;
        public CarrosController(ApplicationDBContext database)
        {
            this.database = database;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Salvar(Carro carro)
        {
            database.Carros.Add(carro);
            database.SaveChanges();
            return Content("salvo");
        }
    }
}