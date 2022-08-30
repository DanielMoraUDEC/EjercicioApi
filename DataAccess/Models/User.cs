using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key,Column(Order = 0)]
        public int UserId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
