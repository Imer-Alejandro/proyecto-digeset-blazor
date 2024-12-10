using System.ComponentModel.DataAnnotations;

public class Multa
    {

        [Key]
        public int Id { get; set; }
        public string CedulaCiudadano { get; set; } = string.Empty;
        public string NombreCiudadano { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Coordenadas { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public bool Activa { get; set; } = true;
        public bool Pagada { get; set; } = false;
         public decimal Monto { get; set; }

        public int AgenteId { get; set; }
        public Agente? Agente { get; set; }
    }