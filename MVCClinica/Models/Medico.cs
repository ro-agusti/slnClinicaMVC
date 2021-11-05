using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCClinica.Models
{
    [Table("Medico")]
    public class Medico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Is Required")]
        [StringLength(150)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Is Required")]
        [StringLength(150)]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Is Required")]
        [StringLength(150)]
        public string Especialidad { get; set; }
    }
}