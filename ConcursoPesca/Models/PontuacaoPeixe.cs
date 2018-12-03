using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConcursoPesca.Models
{
    [Table("PontuacoesPeixes")]
    public partial class PontuacaoPeixe
    {
        [Key, Column(Order = 0)] // isto poderia ser eliminado

        [ForeignKey("Peixe")]
        public int PeixeId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Concurso")]
        public int ConcursoId { get; set; }

        public decimal Pontuacao { get; set; }

        public virtual Peixe Peixe { get; set; }
        public virtual Concurso Concurso { get; set; }
    }
}