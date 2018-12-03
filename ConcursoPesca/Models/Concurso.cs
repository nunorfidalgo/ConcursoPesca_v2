using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConcursoPesca.Models
{
    [Table("Concursos")]
    public partial class Concurso
    {
        public int ConcursoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Hora { get; set; }

        [Required]
        public string Localizacao { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public virtual IList<Pescador> Pescadores { get; set; }
        public virtual IList<Pescaria> Pescarias { get; set; }
        public virtual ICollection<PontuacaoPeixe> PontoacaoPeixes { get; set; }
    }
}