using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreCRUD.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Emp_Code { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Position { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Office_Location { get; set; }
    }
}
