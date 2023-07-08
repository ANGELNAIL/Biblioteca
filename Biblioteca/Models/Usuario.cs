namespace Biblioteca.Models
{
    public class Usuario
    {
        public Int32 IdUsuario { get; set; }
        public String Nombre { get; set; }
        public String Contrasenia { get; set; }
        public String Rol { get; set; }
        public String? Correo { get; set; }
        public String Estado { get; set; }
    }
}
