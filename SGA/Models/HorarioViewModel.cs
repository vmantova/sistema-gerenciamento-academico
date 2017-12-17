using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGA.Models
{
    [NotMapped]
    public class HorarioViewModel
    {
        public string Data { get; set; }
        public string DiaDaSemana { get; set; }
        public string Horario { get; set; }
        public string Materia { get; set; }
        public string Professor { get; set; }
        public int? EmentaId { get; set; }
    }
}