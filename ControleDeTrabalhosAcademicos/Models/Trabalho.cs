namespace ControleDeTrabalhosAcademicos.Models
{
    public class Trabalho
    {
        public int TrabalhoId { get; set; }  // Primary Key
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        
        // Relationships
        public ICollection<Autor> Autores { get; set; }
        public ICollection<Orientador> Orientadores { get; set; }
    }
}
