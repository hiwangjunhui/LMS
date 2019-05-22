using System;
using System.ComponentModel.DataAnnotations;

namespace LibMgmtSys.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50), Required]
        public string UserName { get; set; }

        [StringLength(50), Required]
        public string Password { get; set; }
    }
}
