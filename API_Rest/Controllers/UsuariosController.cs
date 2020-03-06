using System;
using System.Linq;
using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly ApplicationDbContext database;
        public UsuariosController(ApplicationDbContext database)
        {
            this.database = database;

        }

        [HttpPost("registro")]
        public IActionResult Registro([FromBody] Usuario usuario)
        {
            database.Add(usuario);
            database.SaveChanges();
            return Ok(new { msg = "Usuário cadastrado com sucesso" });
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Usuario credenciais)
        {

            try
            {
                Usuario usuario = database.Usuarios.First(User => User.Email.Equals(credenciais.Email));
                if (usuario != null)
                {
                    if (usuario.Senha.Equals(credenciais.Senha))
                    {
                        return Ok("Logado");
                    }
                    else
                    {
                        Response.StatusCode = 401;
                        return new ObjectResult("");
                    }
                }
                else
                {
                    Response.StatusCode = 401;
                    return new ObjectResult("");
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = 401;
                return new ObjectResult("");
            }

        }
    }
}