using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringValidator(MaxLength = 15, MinLength = 2)]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Customer name can contain only letters")]
        public string DepartmentName { get; set; }

        //Navigation Properties

        public List<User> workers { get; set; }

        public List<DepartmentHours> DepartmentHours { get; set; }
    }
}
