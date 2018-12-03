using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConcursoPesca.Models
{
    [Table("Pescarias")]
    public partial class Pescaria
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Concurso")]
        public int ConcursoId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Pescador")]
        public int PescadorId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Peixe")]
        public int PeixeId { get; set; }

        public decimal Gramas { get; set; }

        public virtual Concurso Concurso { get; set; }
        public virtual Pescador Pescador { get; set; }
        public virtual Peixe Peixe { get; set; }

    }
}