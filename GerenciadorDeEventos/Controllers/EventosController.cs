using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeEventos.Data;
using GerenciadorDeEventos.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace GerenciadorDeEventos.Controllers
{
    public class EventosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _hostingEnvironment;

        public EventosController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment;

        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            ViewBag.Local = _context.Locais.ToList();
            return View(await _context.Eventos.ToListAsync());
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.Include(x => x.LocalEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            if (_context.Locais.Count() == 0)
            {
                TempData["Erro"] = "Não é possível cadastrar um evento sem um local cadastrado";
                return RedirectToAction(nameof(Index));

            }
            else
            {

                ViewBag.Local = _context.Locais.ToList();
                return View();
            }
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeEvento,QtdIngressos,DataEvento,VlrIngresso,GeneroEvento,LocalEventoId,DescricaoEvento")] Evento evento, IFormFile files)
        {

            if (ModelState.IsValid)
            {
                evento.LocalEvento = _context.Locais.First(x => x.Id == evento.LocalEventoId);

                if (files != null)
                {
                    _context.Add(evento);
                    await _context.SaveChangesAsync();
                    var extensao = Path.GetExtension(files.FileName).ToLower();
                    var img = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                    var filePath = Path.Combine(img, evento.Id + extensao);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(fileStream);
                    }
                    evento.ImagemEvento = "/img/" + evento.Id + extensao;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Local = _context.Locais.ToList();
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewBag.Local = _context.Locais.ToList();
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeEvento,QtdIngressos,DataEvento,VlrIngresso,GeneroEvento,LocalEventoId,DescricaoEvento,ImagemEvento")] Evento evento, IFormFile files)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    evento.LocalEvento = _context.Locais.First(x => x.Id == evento.LocalEventoId);
                    var eventoDoBanco = _context.Eventos.First(registro => registro.Id == evento.Id);
                    if (files != null)
                    {
                        var extensao = Path.GetExtension(files.FileName).ToLower();
                        var img = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                        var filePath = Path.Combine(img, evento.Id + extensao);

                        if (eventoDoBanco.ImagemEvento != null)
                        {
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath + eventoDoBanco.ImagemEvento);
                        }
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            files.CopyTo(fileStream);
                        }
                        eventoDoBanco.NomeEvento = evento.NomeEvento;
                        eventoDoBanco.QtdIngressos = evento.QtdIngressos;
                        eventoDoBanco.DataEvento = evento.DataEvento;
                        eventoDoBanco.VlrIngresso = evento.VlrIngresso;
                        eventoDoBanco.GeneroEvento = evento.GeneroEvento;
                        eventoDoBanco.LocalEvento = evento.LocalEvento;
                        eventoDoBanco.LocalEventoId = evento.LocalEventoId;
                        eventoDoBanco.DescricaoEvento = evento.DescricaoEvento;
                        eventoDoBanco.ImagemEvento = "/img/" + evento.Id + extensao;
                    }
                    else
                    {
                        eventoDoBanco.NomeEvento = evento.NomeEvento;
                        eventoDoBanco.QtdIngressos = evento.QtdIngressos;
                        eventoDoBanco.DataEvento = evento.DataEvento;
                        eventoDoBanco.VlrIngresso = evento.VlrIngresso;
                        eventoDoBanco.GeneroEvento = evento.GeneroEvento;
                        eventoDoBanco.LocalEvento = evento.LocalEvento;
                        eventoDoBanco.LocalEventoId = evento.LocalEventoId;
                        eventoDoBanco.DescricaoEvento = evento.DescricaoEvento;
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            System.IO.File.Delete(_hostingEnvironment.WebRootPath + evento.ImagemEvento);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
