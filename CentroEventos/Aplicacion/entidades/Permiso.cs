using System.ComponentModel.DataAnnotations;

namespace Aplicacion.entidades
{
    public class Permiso
    {
        [Key] public int _id { get; set; }
        public string _nombre { get; set; } = string.Empty;
        
        public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();

        public Permiso(string nombre)
        {
            _nombre = nombre;
            Personas = new List<Persona>();
        }

        // Constructor sin parámetros para Entity Framework
        protected Permiso()
        {
            _nombre = string.Empty;
            Personas = new List<Persona>();
        }

        public override string ToString()
        {
            return $"Permiso: {_nombre}";
        }
    }
}