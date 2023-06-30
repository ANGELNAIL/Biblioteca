using Biblioteca.BbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("Usuario_Ins")]
        public Int32 Usuario_Ins(DbUsuario usuario)
        {
            Int32 Id = usuario.Usuario_Ins();
            return Id;
        }
    }
}
