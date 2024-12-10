using System.ComponentModel.DataAnnotations;

public class Agente
    {
        [Key]
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        public ICollection<Multa>? Multas { get; set; }
    }