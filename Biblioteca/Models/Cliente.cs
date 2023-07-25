using Biblioteca.BbContext;

namespace Biblioteca.Models
{
    public class Cliente
    {
        public Int32? IdCliente {get;set;}
        public String Nombre { get;set;}
        public String APaterno { get; set; }
        public String? AMaterno { get; set; }
        public Int32? IdUsuario { get; set; }
        public String? Estado { get; set; }
        public String? NombreU { get; set; }
        public String? Contrasenia { get; set; }
        public String? Correo { get; set; }
        public String? Celular { get; set; }
        public String? Telefono { get; set; }

    }
}
