using System.Collections.Generic;

namespace ControleDeTrabalhosAcademicos.Models
{
    public class Trabalho
    {
        public int TrabalhoId { get; set; }
        public string Titulo { get; set; }
        public TipoTrabalho Tipo { get; set; }
        public List<Autor> Autores { get; set; }
        public List<Orientador> Orientadores { get; set; }
    }
}
