using CarrosImportados.Models;
using Microsoft.AspNetCore.Mvc;
using CarrosImportados.Database;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CarrosImportados.Controllers
{
    public class CarrosController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDBContext database;
        public CarrosController(ApplicationDBContext database, IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
            this.database = database;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Carro carro = database.Carros.First(registro => registro.Id == id);
            return View("Editar", carro);
        }

        public IActionResult Index()
        {
            var carros = database.Carros.ToList();
            return View(carros);
        }

        public IActionResult Excluir(int id)
        {
            Carro carro = database.Carros.First(registro => registro.Id == id);
            System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath + carro.Imagem));
            database.Carros.Remove(carro);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Salvar(Carro carro, IFormFile files, int id)
        {
            if (carro.Id == 0)
            {
                database.Carros.Add(carro);
                database.SaveChanges();

                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (files != null && files.Length > 0)
                {
                    var extensao = Path.GetExtension(files.FileName).ToLower();
                    var filePath = Path.Combine(uploads, carro.Id + extensao);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(fileStream);
                    }
                    carro.Imagem = "/uploads/" + carro.Id + extensao;
                }
            }
            else
            {
                var carroDoBanco = database.Carros.First(registro => registro.Id == carro.Id);
                if (files != null)
                {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    var extensao = Path.GetExtension(files.FileName).ToLower();
                    System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath + carroDoBanco.Imagem));
                    var filePath = Path.Combine(uploads, carro.Id + extensao);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(fileStream);
                    }
                    carroDoBanco.Imagem = "/uploads/" + carro.Id + extensao;
                    carroDoBanco.Modelo = carro.Modelo;
                    carroDoBanco.Marca = carro.Marca;
                    carroDoBanco.Cor = carro.Cor;
                    carroDoBanco.Ano = carro.Ano;
                    carroDoBanco.Sobre = carro.Sobre;
                }
                else
                {
                    carroDoBanco.Modelo = carro.Modelo;
                    carroDoBanco.Marca = carro.Marca;
                    carroDoBanco.Cor = carro.Cor;
                    carroDoBanco.Ano = carro.Ano;
                    carroDoBanco.Sobre = carro.Sobre;
                }
            }
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}