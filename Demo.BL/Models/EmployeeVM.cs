using Demo.DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Models
{
    public class EmployeeVM
    {
       
        public EmployeeVM()
        {
            CreationDate = DateTime.Now;
            IsActive = true;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [MinLength(3,ErrorMessage ="Min Lin 3")]
        [StringLength(50, ErrorMessage = "Max Len 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Salary Required")]
        [Range(3000,50000,ErrorMessage ="Range Btw 3K : 50K")]
        public double Salary { get; set; }
        //11-StreetName-City-Country
        [RegularExpression("[0-9]{1,5}-[a-zA-Z]{2,20}-[a-zA-Z]{2,20}-[a-zA-Z]{2,20}", ErrorMessage = "Like : 11-StreetName-City-Country")]
        [Required(ErrorMessage = "Choose Adress")]
        public string Adress { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress(ErrorMessage ="Email Invalid")]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Choose Department")]
        public int DepartmentId { get; set; }
        // [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        
        public int DistrictId { get; set; }
        public District District { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Cv { get; set; }
    }
}
