using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMgmtSys.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50), Required]
        [Display(Name = "图书名称")]
        public string BookName { get; set; }

        [StringLength(50), Required]
        [Display(Name = "作者")]
        public string Author { get; set; }

        [StringLength(50), Required]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "价格")]
        public float Price { get; set; }
    }
}
