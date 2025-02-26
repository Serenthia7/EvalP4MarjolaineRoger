using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Repositories.Entities
{
    public class Application
    {

        [Key]
        [Column("IdApplication")]
        public int IdApplication { get; set; }

        [Required]
        public string Type  { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TypeApplicationId { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }
    }
}
