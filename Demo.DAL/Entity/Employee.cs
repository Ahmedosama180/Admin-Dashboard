using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Demo.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [Required]
        public double Salary { get; set; }
        public string Adress { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        // [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }

    }
}
