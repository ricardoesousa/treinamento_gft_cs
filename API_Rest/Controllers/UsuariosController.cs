using System;
using System.Linq;
using System.Text;
using API_Rest.Data;
using API_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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
                        string chaveDeSeguranca = "school_of_net_manda_muito_bem!";
                        var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveDeSeguranca));
                        var credenciaisDeAcesso = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);

                        var JWT = new JwtSecurityToken(
                            issuer: "ricardo",
                            expires: DateTime.Now.AddHours(1),
                            audience: "usuario_comum",
                            signingCredentials: credenciaisDeAcesso
                        );
                        return Ok (new JwtSecurityTokenHandler().WriteToken(JWT));

                    }
                    else
                    {
                        Response.StatusCode = 401;
                        return new ObjectResult("a");
                    }
                }
                else
                {
                    Response.StatusCode = 401;
                    return new ObjectResult("b");
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = 401;
                return new ObjectResult("c");
            }

        }
    }
}