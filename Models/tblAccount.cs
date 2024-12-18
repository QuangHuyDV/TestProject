using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class tblAccount
    {
        [Key]
        public int Uid { get; set; }

        [StringLength(10)]
        public string? Username { get; set; }

        [StringLength(10)]
        public string? Password { get; set; }
    }
}