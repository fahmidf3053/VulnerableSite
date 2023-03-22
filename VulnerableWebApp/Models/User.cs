using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VulnerableWebApp.Interfaces;
using static VulnerableWebApp.Constants;

namespace VulnerableWebApp.Models
{
    [Table("User")]
    public class User : IEntity
    {

        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
