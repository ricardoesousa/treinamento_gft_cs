using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Desafio05_cs.Models;

namespace Desafio05_cs.Controllers
    {
    public class HomeController : Controller
        {
        private readonly ILogger<HomeController> _logger;

        public HomeController ( ILogger<HomeController> logger )
            {
            _logger = logger;
            }

        public IActionResult Index ( )
            {
            return View ();
            }

        public IActionResult Projects ( )
            {
            return View ();
            }

        public IActionResult Contact ( )
            {
            return View ();
            }

        public IActionResult Skills ( )
            {
            return View ();
            }

        [ResponseCache ( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error ( )
            {
            return View ( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
            }
        }
    }
