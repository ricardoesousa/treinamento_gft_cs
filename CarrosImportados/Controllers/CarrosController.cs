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
        public IActionResult Salvar(Carro carro, IFormFile files)
        {
            if (carro.Id == 0)
            {
                if (files != null)
                {
                    if (files.Length > 0)
                    {
                        var extensao = Path.GetExtension(files.FileName).ToLower();
                        if (extensao == ".jpg" || extensao == ".jpeg" || extensao == ".png")
                        {
                            database.Carros.Add(carro);
                            database.SaveChanges();

                            var extensao2 = Path.GetExtension(files.FileName).ToLower();
                            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                            var filePath = Path.Combine(uploads, carro.Id + extensao2);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                files.CopyTo(fileStream);
                            }
                            carro.Imagem = "/uploads/" + carro.Id + extensao2;
                            database.SaveChanges();
                            TempData["shortMessage"] = "Carro cadastrado com sucesso!";
                            return RedirectToAction("MensagenAdd");
                        }
                        else
                        {
                            ViewBag.Message = "Selecione um arquivo nos formatos .jpg .jpeg .png";
                            return View("Cadastrar");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "O arquivo deve ter tamanho maior que zero bytes";
                        return View("Cadastrar");
                    }
                }
                else
                {
                    ViewBag.Message = "É necessario incluir uma foto do carro para realizar o cadastro";
                    return View("Cadastrar");
                }
            }
            else
            {
                var carroDoBanco = database.Carros.First(registro => registro.Id == carro.Id);
                if (files != null)
                {
                    if (files.Length > 0)
                    {
                        var extensao = Path.GetExtension(files.FileName).ToLower();
                        if (extensao == ".jpg" || extensao == ".jpeg" || extensao == ".png")
                        {
                            var extensao2 = Path.GetExtension(files.FileName).ToLower();
                            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                            var filePath = Path.Combine(uploads, carro.Id + extensao2);
                            System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath + carroDoBanco.Imagem));
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                files.CopyTo(fileStream);
                            }
                            carroDoBanco.Imagem = "/uploads/" + carro.Id + extensao2;
                            carroDoBanco.Modelo = carro.Modelo;
                            carroDoBanco.Marca = carro.Marca;
                            carroDoBanco.Cor = carro.Cor;
                            carroDoBanco.Ano = carro.Ano;
                            carroDoBanco.Sobre = carro.Sobre;
                        }
                        else
                        {
                            ViewBag.Message = "Selecione um arquivo nos formatos .jpg .jpeg .png";
                            return View("Cadastrar");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "O arquivo deve ter tamanho maior que zero bytes";
                        return View("Cadastrar");
                    }
                }
                else
                {
                    carroDoBanco.Modelo = carro.Modelo;
                    carroDoBanco.Marca = carro.Marca;
                    carroDoBanco.Cor = carro.Cor;
                    carroDoBanco.Ano = carro.Ano;
                    carroDoBanco.Sobre = carro.Sobre;
                }
                    database.SaveChanges();
                    return RedirectToAction("Index");
            }
        }

        public ActionResult MensagenAdd()
        {
            ViewBag.Message = TempData["shortMessage"];
            return View("Cadastrar");
        }
    }
}