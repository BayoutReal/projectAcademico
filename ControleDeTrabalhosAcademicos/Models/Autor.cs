namespace ControleDeTrabalhosAcademicos.Models
{
    public class Autor
    {
        public int AutorId { get; set; }  // Primary Key
        public string Nome { get; set; }
        public string Curso { get; set; }
        
        // Relationships
        public int TrabalhoId { get; set; }
        public Trabalho Trabalho { get; set; }
    }
}
