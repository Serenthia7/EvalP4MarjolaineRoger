using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class Password
    {
        [Key]
        public int IdPassword { get; set; }

        [ForeignKey(nameof(Application))]
        public int IdApplication { get; set; }
        [Required]
        [MinLength(10)]
        public string Libelle { get; set; }

        public Application? Application { get; set; }
    }
}
