using System;
using System.ComponentModel.DataAnnotations.Schema;
using VulnerableWebApp.Interfaces;
using static VulnerableWebApp.Constants;

namespace VulnerableWebApp.Models
{
    [Table("Request")]
    public class Request : IEntity
    {
        public int Id { get; set; }
        public string RequestFrom { get; set; }
        public string RequestTo { get; set; }
        public DateTime CreatedTime { get; set; }

        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
