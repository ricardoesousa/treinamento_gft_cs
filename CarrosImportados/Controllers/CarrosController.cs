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

        /*
        public async Task<IActionResult> Salvar(Carro carro, IList<IFormFile> files)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    carro.Imagem = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(carro.Imagem, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

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
        } */

        public IActionResult Salvar(Carro carro, IFormFile files)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (files.Length > 0)
            {
                var filePath = Path.Combine(uploads, files.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyTo(fileStream);
                }
                carro.Imagem = "/uploads/" + files.FileName;
            }

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