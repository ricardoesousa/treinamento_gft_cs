using CarrosImportados.Models;
using Microsoft.AspNetCore.Mvc;
using CarrosImportados.Database;
using System.Linq;

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

        public IActionResult Editar(int id)
        {
            var carro = database.Carros.First(registro => registro.Id == id);
            return View("Cadastrar", carro);
        }

        public IActionResult Index()
        {
            var carros = database.Carros.ToList();
            return View(carros);
        }

        public IActionResult Excluir(Carro carro)
        {
            database.Carros.Remove(carro);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Salvar(Carro carro)
        {
            if (carro.Id == 0)
            {
                database.Carros.Add(carro);
            }
            else
            {
                var carroDoBanco = database.Carros.First(registro => registro.Id == carro.Id);
                carroDoBanco.Modelo = carro.Modelo;
                carroDoBanco.Marca = carro.Marca;
                carroDoBanco.Cor = carro.Cor;
                carroDoBanco.Ano = carro.Ano;
                carroDoBanco.Sobre = carro.Sobre;
                carroDoBanco.Imagem = carro.Imagem;
            }
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}