using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConcursoPesca.Models
{
    [Table("Pescadores")]
    public partial class Pescador
    {
        public int PescadorId { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        public string Morada { get; set; }

        public int BI { get; set; }

        public int NIF { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy", ApplyFormatInEditMode = true)]
        public string DataNascimento { get; set; }

        public string NLicencaPesca { get; set; }

        public Categoria? Categoria { get; set; }

        public virtual IList<Concurso> Concursos { get; set; }
        public virtual IList<Pescaria> Pescarias { get; set; }
    }
}