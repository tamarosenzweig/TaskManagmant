using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class DepartmentHours
    {
        [Key]
        public int DepartmentHoursId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "'NumHours' must be above 0")]
        //customer validation NumHours=sum worker hours in this department
        public int NumHours { get; set; }

        //Navigation Properties

        public Project Project { get; set; }

        public Department Department { get; set; }

    }
}
