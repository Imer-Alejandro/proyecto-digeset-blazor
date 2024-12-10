using System.ComponentModel.DataAnnotations;

public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty; // Ejemplo: "Admin", "Central"
    }