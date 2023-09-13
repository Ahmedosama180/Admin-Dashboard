using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Required")]
        [StringLength(50,ErrorMessage ="Max Len 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code Required")]
        public string Code { get; set; }
    }
}
