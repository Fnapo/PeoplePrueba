using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Modelos
{
    [Table("persona")]
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250), Required]
        public string Nombre { get; set; }
    }
}
